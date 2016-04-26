using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Analise_E_Simulacao_Tarifacao_Energia.Models
{
    public class DistribuidoraModel
    {
        [ScaffoldColumn(false)]
        public int DistribuidoraID { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
    }
}