using Analise_E_Simulacao_Tarifacao_Energia.Models;
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

        public FabricaViewModel()
        {
            distribuidoras = new List<SelectListItem>();
        }

        public FabricaViewModel(FabricaModel _fabrica, IEnumerable<DistribuidoraModel> _distribuidoras)
        {
            if(_fabrica != null)
            {
                FabricaID = _fabrica.FabricaID;
                ClienteID = _fabrica.ClienteID;
                Cnpj = _fabrica.Cnpj;
                DistribuidoraID = _fabrica.DistribuidoraID;
                Endereco = _fabrica.Endereco;
            }

            distribuidoras = new List<SelectListItem>();

            foreach (var d in _distribuidoras)
            {
                distribuidoras.Add(new SelectListItem
                {
                    Text = d.Nome,
                    Value = d.DistribuidoraID.ToString()
                });
            }
        }
    }
}
