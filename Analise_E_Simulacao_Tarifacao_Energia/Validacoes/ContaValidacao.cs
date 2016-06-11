using Analise_E_Simulacao_Tarifacao_Energia.Models;
using Analise_E_Simulacao_Tarifacao_Energia.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analise_E_Simulacao_Tarifacao_Energia.Validacoes
{
    public static class ContaValidacao
    {
        public static List<Validacao> validacoes { get; private set; }
        private static ContaModel conta;
        private static string entidade = "Conta";

        public static void ValidaCriacaoConta(ContaModel _conta)
        {
            conta = _conta;
            validacoes = new List<Validacao>();

            if (conta != null)
            {
                ValidaObrigatoriedade();
                ValidaDuplicidade();
            }
        }

        public static void ValidaAtualizacaoConta(ContaModel _conta)
        {
            conta = _conta;
            validacoes = new List<Validacao>();

            if (conta != null)
                ValidaObrigatoriedade();
        }

        private static void ValidaObrigatoriedade()
        {
            string tipo = "Obrigatoriedade";

            if (conta.dataReferencia == DateTime.MinValue)
                validacoes.Add(new Validacao(
                                _entidade: entidade
                                , _tipo: tipo
                                , _mensagem: "O periodo selecionado é invalido."
                                ));

            if (conta.TarifaID == 0)
                validacoes.Add(new Validacao(
                                _entidade: entidade
                                , _tipo: tipo
                                , _mensagem: "A combinação de distribuidora, bandeira, contrato e sub grupo não compõe uma tarifa válida."
                                ));
        }

        private static void ValidaDuplicidade()
        {
            string tipo = "Duplicidade";
            ServiceReference1.Conta c;

            if (validacoes.Count == 0)
            {
                using (ServiceReference1.TEE_BUS_Service1Client client = new ServiceReference1.TEE_BUS_Service1Client())
                {
                    c = client.DestalhesDaConta(conta.dataReferencia, conta.FabricaID);

                }

                if (c.dataReferencia != DateTime.MinValue)
                    validacoes.Add(new Validacao(
                                    _entidade: entidade
                                    , _tipo: tipo
                                    , _mensagem: "Já existe uma conta cadastrada nesse periodo."
                                    ));
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
                    mensagem += Environment.NewLine + v.mensagem;
                }
            }

            return mensagem;
        }
    }
}