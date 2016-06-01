using Analise_E_Simulacao_Tarifacao_Energia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Analise_E_Simulacao_Tarifacao_Energia.Validacoes
{
    public static class UsuarioValidacao
    {
        public static List<Validacao> validacoes { get; private set; }
        private static UsuarioModel usuario;
        private static string entidade = "Usuario";

        public static void ValidaCriacaoUsuario(UsuarioModel _usuario)
        {
            usuario = _usuario;
            validacoes = new List<Validacao>();

            if (usuario != null)
            {
                ValidaObrigatoriedade(usuario.Email, "email");
                ValidaDuplicidade();
            }
        }

        public static void ValidaAtualizacaoUsuario(UsuarioModel _usuario)
        {
            usuario = _usuario;
            validacoes = new List<Validacao>();

            if (usuario != null)
            {
                ValidaObrigatoriedade(usuario.Nome, "nome");
            }
        }

        private static void ValidaObrigatoriedade(string valor, string campo)
        {
            string tipo = "Obrigatoriedade";

            if (string.IsNullOrWhiteSpace(valor))
                validacoes.Add(new Validacao(
                                _entidade: entidade
                                , _tipo: tipo
                                , _mensagem: "O campo " + campo + " é obrigatório."
                                ));
        }

        private static void ValidaEmail()
        {
            string tipo = "Formatação";

            if (!EmailValido(usuario.Email))
                validacoes.Add(new Validacao(
                                _entidade: entidade
                                , _tipo: tipo
                                , _mensagem: "Formato de email invalido."
                                ));
        }

        private static bool EmailValido(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private static void ValidaDuplicidade()
        {
            string tipo = "Duplicidade";
            ServiceReference1.Usuario u;

            if (validacoes.Count == 0)
            {
                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    u = client.DestalhesDoUsuario(usuario.Email);

                }

                if (u.Email == usuario.Email)
                    validacoes.Add(new Validacao(
                                    _entidade: entidade
                                    , _tipo: tipo
                                    , _mensagem: "Já existe um usuario com esse email."
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

            if(validacoes != null)
            {
                foreach(var v in validacoes)
                {
                    mensagem += Environment.NewLine + v.mensagem;
                }
            }

            return mensagem;
        }
    }
}
