using HC = DotNet.Highcharts;
using Analise_E_Simulacao_Tarifacao_Energia.Models;
using Analise_E_Simulacao_Tarifacao_Energia.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;

namespace Analise_E_Simulacao_Tarifacao_Energia.Controllers
{
    public class SimulacaoController : Controller
    {

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
                List<HC.Options.Series> series = new List<HC.Options.Series>();
                object[][] eixoY = null;
                string serieName = "";
                int contratoAtualID = 0;
                string nomeContrato = "";
                Color color = Color.Black;

                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    var listaDeEntrada = client.TodasContas(auxFabricaID).ToList();
                    var contratoRef = client.TodosContratos().ToList();
                    
                    listaConta = Conversor.ListaContas(listaDeEntrada);
                    contratos = Conversor.ListaContratos(contratoRef);

                    contratoAtualID = (listaConta.OrderByDescending(c => c.dataReferencia)).Select(c => c.TipoContratoID).FirstOrDefault();
                    nomeContrato = contratos.Where(c => c.TipoContratoID == contratoAtualID).Select(c => c.TipoContratoString).FirstOrDefault();

                    if (nomeContrato == "Verde")
                    {
                        color = Color.Green;
                    }
                    else if(nomeContrato == "Azul")
                    {
                        color = Color.Blue;
                    }

                    eixoY = listaConta.Select(c => new object[] { Math.Round(Convert.ToDouble(c.ValorTotal),2) }).ToArray();
                    serieName = "Tarifa " + nomeContrato +  " (Atual)";
                    series.Add(new HC.Options.Series { Name = serieName, Data = new HC.Helpers.Data(eixoY), Color = color });

                    foreach (var c in contratos)
                    {
                        var graficoReferente = client.DadosParaGrafico(auxFabricaID, c.TipoContratoID).ToList();

                        if (graficoReferente != null && graficoReferente.Count !=0)
                        {
                            graficoModel = Conversor.DadosGrafico(graficoReferente);
                            eixoY = graficoModel.Select(g => new object[] { Math.Round(Convert.ToDouble(g.ValorTotal),2) }).ToArray();
                            nomeContrato = c.TipoContratoString;

                            if (nomeContrato == "Verde")
                            {
                                color = Color.Green;
                            }
                            else if (nomeContrato == "Azul")
                            {
                                color = Color.Blue;
                            }
                            else
                            {
                                color = Color.Black;
                            }

                            serieName = "Tarifa " + nomeContrato;
                            series.Add(new HC.Options.Series { Name = serieName, Data = new HC.Helpers.Data(eixoY), Color = color });
                        }
                    }
                }

                var xMes = listaConta.Select(c => c.MesReferencia).Distinct().ToArray();

                HC.Highcharts chart = new HC.Highcharts("chart")
                        .SetXAxis(new HC.Options.XAxis { Categories = xMes })
                        .SetYAxis(new HC.Options.YAxis { Title = new HC.Options.YAxisTitle { Text = "Valores" } })
                        .SetSeries(series.ToArray())
                        .SetTitle(new HC.Options.Title { Text = "Tarifas de energia" })
                        .InitChart(new DotNet.Highcharts.Options.Chart { DefaultSeriesType = DotNet.Highcharts.Enums.ChartTypes.Line });

                return View(chart);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Erro", new { area = "" });
            }
        }
    }
}
