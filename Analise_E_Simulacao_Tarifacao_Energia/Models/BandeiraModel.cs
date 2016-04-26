using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Analise_E_Simulacao_Tarifacao_Energia.Models
{
    public class BandeiraModel
    {
        [ScaffoldColumn(false)]
        public int BandeiraID { get; set; }
        public string BandeiraString { get; set; }
    }
}