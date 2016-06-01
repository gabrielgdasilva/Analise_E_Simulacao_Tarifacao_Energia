using HC = DotNet.Highcharts;
using Analise_E_Simulacao_Tarifacao_Energia.Models;
using Analise_E_Simulacao_Tarifacao_Energia.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analise_E_Simulacao_Tarifacao_Energia.Controllers
{
    public class SimulacaoController : Controller
    {
        // GET: Simulacao
        [VerificaAutenticacao]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Simulacao/Details/5
        [VerificaAutenticacao]
        public ActionResult Details(int id)
        {
            SimulacaoModel simulacaoModelo = new SimulacaoModel();
            return View(simulacaoModelo);
        }

        // GET: Simulacao/Create
        [VerificaAutenticacao]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Simulacao/Create
        [HttpPost]
        public ActionResult GerarSimulacao()
        {
            try
            {
                int? fabricaID = Session["IdFabrica"] as int?;
                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    bool resultado = client.GerarSimulacao((fabricaID != null) ? (int) fabricaID : 0);
                    if (resultado)
                    {
                        TempData["GerarSimulacao"] = true;
                        return RedirectToAction("Chart");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Erro", new { area = "" });
                    }
                }
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Erro", new { area = "" });
            }
        }

        // GET: Simulacao/Edit/5
        [VerificaAutenticacao]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Simulacao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Simulacao/Delete/5
        [VerificaAutenticacao]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Simulacao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [VerificaAutenticacao]
        public ActionResult Chart()
        {
            try
            {
                int? fabricaID = Session["IdFabrica"] as int?;
                int auxFabricaID = (fabricaID != null) ? (int)fabricaID : 0;

                List<ContaModel> listaConta = new List<ContaModel>();
                List<TipoContratoModel> contratos = new List<TipoContratoModel>();
                List<TipoSubGrupoModel> grupos = new List<TipoSubGrupoModel>();
                List<GraficoModel> graficoModel = new List<GraficoModel>();

                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    var graficoReferente = client.DadosParaGrafico(auxFabricaID).ToList();
                    var listaDeEntrada = client.TodasContas(auxFabricaID).ToList();
                    var contratoRef = client.TodosContratos().ToList();
                    var gruposRef = client.TodosSubGrupos().ToList();

                    graficoModel = Conversor.DadosGrafico(graficoReferente);
                    listaConta = Conversor.ListaContas(listaDeEntrada);
                    contratos = Conversor.ListaContratos(contratoRef);
                    grupos = Conversor.ListaSubGrupos(gruposRef);
                }

                var series = new HC.Options.Series[2];
                var serieName = "Consumo atual";
                var eixoY = listaConta.Select(c => new object[] { Convert.ToDouble(c.ValorTotal) }).ToArray();

                series[0] = new HC.Options.Series { Name = serieName, Data = new HC.Helpers.Data(eixoY) };

                var exemplo = graficoModel.FirstOrDefault();
                string strContrato = contratos.Where(x => x.TipoContratoID == exemplo.TipoContratoID).Select(x => x.TipoContratoString).ToString();
                string strGrupo = grupos.Where(x => x.TipoSubGrupoID == exemplo.TipoSubGrupoID).Select(x => x.TipoSubGrupoString).ToString();
                serieName = "Contrato simulado";//strGrupo + " " + strGrupo;
                eixoY = graficoModel.Select(c => new object[] { Convert.ToDouble(c.ValorTotal) }).ToArray();

                series[1] = new HC.Options.Series { Name = serieName, Data = new HC.Helpers.Data(eixoY) };

                var xMes = listaConta.Select(c => c.MesReferencia).Distinct().ToArray();
                //var yValores = contas.Select(c => new object[] { c.ValorTotal }).ToArray();

                HC.Highcharts chart = new HC.Highcharts("chart")
                        .SetXAxis(new HC.Options.XAxis { Categories = xMes })
                        .SetYAxis(new HC.Options.YAxis { Title = new HC.Options.YAxisTitle { Text = "Valores" } })
                        .SetSeries(series)
                        .SetTitle(new HC.Options.Title { Text = "Consumo de energia" })
                        .InitChart(new DotNet.Highcharts.Options.Chart { DefaultSeriesType = DotNet.Highcharts.Enums.ChartTypes.Line });


                /*var chart = new HC.Highcharts("chart")
                    //Tipo do grafico
                    .InitChart(new HC.Options.Chart { DefaultSeriesType = HC.Enums.ChartTypes.Line })
                    //Titulo
                    .SetTitle(new HC.Options.Title { Text = "Consumo de energia" })
                    .SetSubtitle(new HC.Options.Subtitle { Text = "Historico" })
                    //Valores eixo x
                    .SetXAxis(new HC.Options.XAxis { Categories = xMes })
                    //Valores eixo y
                    .SetYAxis(new HC.Options.YAxis { Title = new HC.Options.YAxisTitle { Text = "Valores" } })
                    .SetTooltip(new HC.Options.Tooltip
                    {
                        Enabled = true,
                        Formatter = @"function() { return '<b>'+ this.series.name +'</b><br/>'+ this.x +': '+ this.y; }"
                    })
                    .SetPlotOptions(new HC.Options.PlotOptions
                    {
                        Line = new HC.Options.PlotOptionsLine
                        {
                            DataLabels = new HC.Options.PlotOptionsLineDataLabels
                            {
                                Enabled = true
                            },
                            EnableMouseTracking = false
                        }
                    })
                    .SetSeries(series);*/
                /*.SetSeries(new HC.Options.Series[]
                {
                    new HC.Options.Series { Name = "Valor $", Data = new HC.Helpers.Data(yValores) }
                    //,new HC.Options.Series { Name = "Outra liha", Data = new HC.Helpers.Data(valores) }
                });*/

                return View(chart);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Erro", new { area = "" });
            }
        }
    }
}
