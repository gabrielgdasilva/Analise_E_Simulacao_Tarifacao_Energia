using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Analise_E_Simulacao_Tarifacao_Energia.Models
{
    public class TipoContratoModel
    {
        [ScaffoldColumn(false)]
        public int TipoContratoID { get; set; }
        public string TipoContratoString { get; set; }
    }
}