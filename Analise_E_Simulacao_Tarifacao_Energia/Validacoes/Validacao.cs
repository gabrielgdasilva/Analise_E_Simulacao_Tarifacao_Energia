using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analise_E_Simulacao_Tarifacao_Energia.Validacoes
{
    public class Validacao
    {
        public string entidade { get; set; }
        public string tipo { get; set; }
        public string mensagem { get; set; }

        public Validacao(string _entidade, string _tipo, string _mensagem)
        {
            entidade = _entidade;
            tipo = _tipo;
            mensagem = _mensagem;
        }
    }
}
