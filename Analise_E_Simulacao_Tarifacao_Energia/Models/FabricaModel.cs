using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Analise_E_Simulacao_Tarifacao_Energia.Models
{
    public class FabricaModel
    {
        [ScaffoldColumn(false)]
        public int FabricaID { get; set; }
        public int ClienteID { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public int DistribuidoraID { get; set; }
    }
}