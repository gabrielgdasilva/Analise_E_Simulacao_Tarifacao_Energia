using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Analise_E_Simulacao_Tarifacao_Energia.ViewModels
{
    public class FabricaViewModel
    {
        public int FabricaID { get; set; }
        public int ClienteID { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public int DistribuidoraID { get; set; }
        public List<SelectListItem> distribuidoras { get; set; }
    }
}
