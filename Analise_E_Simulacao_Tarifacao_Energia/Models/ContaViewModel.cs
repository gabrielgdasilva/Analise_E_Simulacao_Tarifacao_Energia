using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Analise_E_Simulacao_Tarifacao_Energia.Models
{
    public class ContaViewModel
    {
        public ContaModel conta { get; set; }
        public List<SelectListItem> bandeiras { get; set; }
        public List<SelectListItem> meses { get; set; }
        public List<SelectListItem> distribuidoras { get; set; }
        public List<SelectListItem> tiposContrato { get; set; }
        public List<SelectListItem> tiposSubGrupo { get; set; }
        public List<ContaModel> contas { get; set; }
        public string bandeiraID { get; set; }
        public string tarifaID { get; set; }
        public string contratoID { get; set; }
        public string subGrupoID { get; set; }
        public string Ano { get; set; }
        public string Mes { get; set; }

        public ContaViewModel()
        {
            Ano = "";
            Mes = "";
            bandeiraID = "";
            tarifaID = "";
            contratoID = "";
            subGrupoID = "";
            conta = new ContaModel();
            bandeiras = new List<SelectListItem>();
            meses = new List<SelectListItem>();
            distribuidoras = new List<SelectListItem>();
            tiposContrato = new List<SelectListItem>();
            tiposSubGrupo = new List<SelectListItem>();
            contas = new List<ContaModel>();

        }

        public ContaViewModel(int fabricaID, IEnumerable<ContaModel> _contas)
        {
            conta = new ContaModel();
            conta.FabricaID = fabricaID;
            contas = new List<ContaModel>(_contas);
        }

        public ContaViewModel(
            ContaModel _conta,
            IEnumerable<BandeiraModel> _bandeiras,
            IEnumerable<Mes> _meses,
            IEnumerable<DistribuidoraModel> _distribuidoras,
            IEnumerable<TipoContratoModel> _tiposContrato,
            IEnumerable<TipoSubGrupoModel> _tiposSubGrupo
            )
        {
            conta = _conta;
            if (conta != null)
            {
                Ano = conta.dataReferencia.ToString("yyyy");
                Mes = conta.dataReferencia.ToString("MM");
            }
            else
            {
                Ano = "";
                Mes = "";
                bandeiraID = "";
                tarifaID = "";
                contratoID = "";
                subGrupoID = "";
                conta = new ContaModel();
            }

            bandeiras = new List<SelectListItem>();
            meses = new List<SelectListItem>();
            distribuidoras = new List<SelectListItem>();
            tiposContrato = new List<SelectListItem>();
            tiposSubGrupo = new List<SelectListItem>();

            foreach (var b in _bandeiras)
            {
                bandeiras.Add(new SelectListItem
                {
                    Text = b.BandeiraString,
                    Value = b.BandeiraID.ToString()
                });
            }

            foreach(var m in _meses)
            {
                meses.Add(new SelectListItem
                    {
                        Text = m.NomeMes,
                        Value = m.NumeroMes
                    });
            }

            foreach(var c in _tiposContrato)
            {
                tiposContrato.Add(new SelectListItem
                    {
                        Text = c.TipoContratoString,
                        Value = c.TipoContratoID.ToString()
                    });
            }

            foreach(var g in _tiposSubGrupo)
            {
                tiposSubGrupo.Add(new SelectListItem
                    {
                        Text =g.TipoSubGrupoString,
                        Value = g.TipoSubGrupoID.ToString()
                    });
            }

            foreach (var d in _distribuidoras)
            {
                distribuidoras.Add(new SelectListItem
                {
                    Text = d.Nome,
                    Value = d.DistribuidoraID.ToString()
                });
            }
        }

        public ContaModel ObterConta()
        {
            conta.dataReferencia = (!string.IsNullOrWhiteSpace(Mes) && !string.IsNullOrWhiteSpace(Ano)) ? Convert.ToDateTime("01/" + Mes + "/" + Ano) : DateTime.MinValue;
            //conta.TarifaID = tarifas.Where(x => x.TipoContratoID == conta.TipoContratoID && x.TipoSubGrupoID == conta.TipoSubGrupoID && x.BandeiraID == conta.BandeiraID).Select(x => x.TarifaID).FirstOrDefault();
            //conta.BandeiraID = (!string.IsNullOrWhiteSpace(bandeiraID)) ? Convert.ToInt32(bandeiraID) : 0;
            //conta.TarifaID = (!string.IsNullOrWhiteSpace(tarifaID)) ? Convert.ToInt32(tarifaID) : 0;
            //conta.TipoContratoID = (!string.IsNullOrWhiteSpace(contratoID)) ? Convert.ToInt32(contratoID) : 0;
            //conta.TipoSubGrupoID = (!string.IsNullOrWhiteSpace(subGrupoID)) ? Convert.ToInt32(subGrupoID) : 0;
            return conta;
        }
    }
}