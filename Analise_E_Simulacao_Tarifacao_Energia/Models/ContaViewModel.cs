using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analise_E_Simulacao_Tarifacao_Energia.Models
{
    public class ContaViewModel
    {
        public ContaModel conta { get; set; }
        public List<BandeiraModel> bandeiras { get; set; }
        public List<Mes> meses { get; set; }
        public List<TarifaModel> tarifas { get; set; }
        public List<TipoContratoModel> tiposContrato { get; set; }
        public List<TipoSubGrupoModel> tiposSubGrupo { get; set; }
        public string Ano { get; set; }
        public string Mes { get; set; }

        public ContaViewModel(
            ContaModel _conta,
            IEnumerable<BandeiraModel> _bandeiras,
            IEnumerable<Mes> _meses,
            IEnumerable<TarifaModel> _tarifas,
            IEnumerable<TipoContratoModel> _tiposContrato,
            IEnumerable<TipoSubGrupoModel> _tiposSubGrupo
            )
        {
            conta = _conta;
            if(conta != null)
            {
                Ano = conta.dataReferencia.ToString("yyyy");
                Mes = conta.dataReferencia.ToString("MM");
            }
            else
            {
                conta = new ContaModel();
            }
            
            bandeiras = new List<BandeiraModel>(_bandeiras);
            meses = new List<Mes>(_meses);
            tarifas = new List<TarifaModel>(_tarifas);
            tiposContrato = new List<TipoContratoModel>(_tiposContrato);
            tiposSubGrupo = new List<TipoSubGrupoModel>(_tiposSubGrupo);
        }

        public ContaModel ObterConta()
        {
            conta.dataReferencia = Convert.ToDateTime("01/" + Mes + "/" + Ano);
            return conta;
        }
    }
}
