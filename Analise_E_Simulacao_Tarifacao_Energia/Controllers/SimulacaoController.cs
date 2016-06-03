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
                List<HC.Options.Series> series = new List<HC.Options.Series>();
                object[][] eixoY = null;
                string serieName = "";

                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    var listaDeEntrada = client.TodasContas(auxFabricaID).ToList();
                    var contratoRef = client.TodosContratos().ToList();
                    
                    listaConta = Conversor.ListaContas(listaDeEntrada);
                    contratos = Conversor.ListaContratos(contratoRef);

                    eixoY = listaConta.Select(c => new object[] { Math.Round(Convert.ToDouble(c.ValorTotal),2) }).ToArray();
                    serieName = "Tarifa Atual";
                    series.Add(new HC.Options.Series { Name = serieName, Data = new HC.Helpers.Data(eixoY) });

                    foreach (var c in contratos)
                    {
                        var graficoReferente = client.DadosParaGrafico(auxFabricaID, c.TipoContratoID).ToList();

                        if (graficoReferente != null && graficoReferente.Count !=0)
                        {
                            graficoModel = Conversor.DadosGrafico(graficoReferente);
                            eixoY = graficoModel.Select(g => new object[] { Math.Round(Convert.ToDouble(g.ValorTotal),2) }).ToArray();
                            serieName = c.TipoContratoString;
                            series.Add(new HC.Options.Series { Name = serieName, Data = new HC.Helpers.Data(eixoY) });
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
