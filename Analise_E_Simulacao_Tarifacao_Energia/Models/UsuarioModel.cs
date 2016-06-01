using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Analise_E_Simulacao_Tarifacao_Energia.Models
{
    public class UsuarioModel
    {
        public string Email { get; set; }
        public int ClienteID { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataRegistro { get; set; }
        public int Tipo { get; set; }
        public string MascaraCPF
        {
            get { return (!string.IsNullOrWhiteSpace(Cpf)) ? Convert.ToUInt64(Cpf).ToString(@"000\.000\.000\-00") : ""; }
        }
    }
}