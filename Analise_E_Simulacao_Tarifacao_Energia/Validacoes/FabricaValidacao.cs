using Analise_E_Simulacao_Tarifacao_Energia.Models;
using Analise_E_Simulacao_Tarifacao_Energia.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analise_E_Simulacao_Tarifacao_Energia.Validacoes
{
    public static class FabricaValidacao
    {
        public static List<Validacao> validacoes { get; private set; }
        private static FabricaModel fabrica;
        private static string entidade = "Fabrica";

        public static void ValidaFabrica(FabricaModel _fabrica)
        {
            fabrica = _fabrica;
            validacoes = new List<Validacao>();

            if (fabrica != null)
            {
                ValidaObrigatoriedade();
                ValidaCNPJ(fabrica.Cnpj);
                ValidaDuplicidade();
            }
        }

        private static void ValidaObrigatoriedade()
        {
            string tipo = "Obrigatoriedade";

            if (string.IsNullOrWhiteSpace(fabrica.Cnpj))
                validacoes.Add(new Validacao(
                                _entidade: entidade
                                , _tipo: tipo
                                , _mensagem: "O campo CNPJ é obrigatório."
                                ));

            if (string.IsNullOrWhiteSpace(fabrica.Endereco))
                validacoes.Add(new Validacao(
                                _entidade: entidade
                                , _tipo: tipo
                                , _mensagem: "Endereço é obrigatório."
                                ));

            if (fabrica.DistribuidoraID == 0)
                validacoes.Add(new Validacao(
                                _entidade: entidade
                                , _tipo: tipo
                                , _mensagem: "É obrigatório escolher uma destribuidora."
                                ));
        }

        private static void ValidaCNPJ(string cnpj)
        {
            string tipo = "Formatacao";

            if (!string.IsNullOrWhiteSpace(cnpj))
            {
                if(cnpj.Length != 14)
                    validacoes.Add(new Validacao(
                                    _entidade: entidade
                                    , _tipo: tipo
                                    , _mensagem: "CNPJ deve conter 14 digitos."
                                    ));
                else if (!ValidaFormatoCNPJ(cnpj))
                    validacoes.Add(new Validacao(
                                    _entidade: entidade
                                    , _tipo: tipo
                                    , _mensagem: "Formato de CNPJ invalido."
                                    ));
            }
        }

        private static bool ValidaFormatoCNPJ(string cnpj)
        {
            // Elimina CNPJs invalidos conhecidos
            if (cnpj == "00000000000000" ||
                cnpj == "11111111111111" ||
                cnpj == "22222222222222" ||
                cnpj == "33333333333333" ||
                cnpj == "44444444444444" ||
                cnpj == "55555555555555" ||
                cnpj == "66666666666666" ||
                cnpj == "77777777777777" ||
                cnpj == "88888888888888" ||
                cnpj == "99999999999999")
                return false;

            // Valida DVs
            try
            {
                int tamanho = cnpj.Length - 2;
                string numeros = cnpj.Substring(0, tamanho);
                string digitos = cnpj.Substring(tamanho);
                int soma = 0;
                int pos = tamanho - 7;
                int resultado = 0;

                for (int i = tamanho; i >= 1; i--)
                {
                    soma += Convert.ToInt32(numeros[tamanho - i]) * pos--;
                    if (pos < 2)
                        pos = 9;
                }
                resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                if (resultado != Convert.ToInt32(digitos[0]))
                    return false;

                tamanho = tamanho + 1;
                numeros = cnpj.Substring(0, tamanho);
                soma = 0;
                pos = tamanho - 7;
                for (int i = tamanho; i >= 1; i--)
                {
                    soma += Convert.ToInt32(numeros[tamanho - i]) * pos--;
                    if (pos < 2)
                        pos = 9;
                }
                resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                if (resultado != Convert.ToInt32(digitos[1]))
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void ValidaDuplicidade()
        {
            string tipo = "Duplicidade";
            List<FabricaModel> fabricas = new List<FabricaModel>();
            string cnpj2;

            if (validacoes.Count == 0)
            {
                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    List<ServiceReference1.Fabrica> listaDeEntrada = client.TodasFabricas(fabrica.ClienteID).ToList();
                    fabricas = Conversor.ListaFabricas(listaDeEntrada);
                }

                if (fabricas.Count > 0)
                {
                    cnpj2 = fabricas.Where(f => f.Cnpj == fabrica.Cnpj && f.FabricaID != fabrica.FabricaID).Select(f => f.Cnpj).FirstOrDefault();
                    if (fabrica.Cnpj == cnpj2)
                        validacoes.Add(new Validacao(
                                        _entidade: entidade
                                        , _tipo: tipo
                                        , _mensagem: "Já existe uma fabrica cadastrada nesse mesmo CNPJ."
                                        ));
                }
            }
        }

        public static bool Valido()
        {
            if (validacoes != null)
                return (validacoes.Count == 0);
            else
                return true;
        }

        public static string ObterMensagem()
        {
            string mensagem = "";

            if (validacoes != null)
            {
                foreach (var v in validacoes)
                {
                    mensagem += Environment.NewLine + v.tipo + ": " + v.mensagem;
                }
            }

            return mensagem;
        }
    }
}
