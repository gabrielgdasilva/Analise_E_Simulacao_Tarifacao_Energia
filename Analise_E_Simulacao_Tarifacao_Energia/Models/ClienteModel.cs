using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Analise_E_Simulacao_Tarifacao_Energia.Models
{
    public class ClienteModel
    {
        [ScaffoldColumn(false)]
        public int ClienteID { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Endereco { get; set; }
        public string MascaraCNPJ
        {
            get { return Convert.ToUInt64(Cnpj).ToString(@"00\.000\.000\/0000\-00"); }
        }
    }
}