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
        public ActionResult Index()
        {
            return View();
        }

        // GET: Simulacao/Details/5
        public ActionResult Details(int id)
        {
            SimulacaoModel simulacaoModelo = new SimulacaoModel();
            return View(simulacaoModelo);
        }

        // GET: Simulacao/Create
        public ActionResult Create()
        {
            SimulacaoModel simulacaoModelo = new SimulacaoModel();
            return View(simulacaoModelo);
        }

        // POST: Simulacao/Create
        [HttpPost]
        public ActionResult Create(FabricaModel modeloFabrica)
        {
            try
            {
                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    ServiceReference1.Fabrica fabrica = Conversor.IniciarSimulacao(modeloFabrica);
                    bool resultado = client.GerarSimulacao(fabrica.FabricaID);
                    if (resultado)
                    {
                        TempData["GerarSimulacao"] = true;
                        return RedirectToAction("Details");
                    }
                    else
                    {
                        throw new InvalidOperationException("O Serviço não pode solicitar a Ação. Verifique se o mesmo encontra-se preenchido corretamente");
                    }
                }
            }
            catch(Exception ex)
            {
                ViewBag.GerarSimulacao = false;
                ViewBag.ErroGerarSimulacao = ex.Message;
                return View();
            }
        }

        // GET: Simulacao/Edit/5
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

        public ActionResult Chart()
        {
            ServiceReference1.Grafico grafico = new ServiceReference1.Grafico();
            List<ServiceReference1.Grafico> graficoReference = new List<ServiceReference1.Grafico>();
            graficoReference.Add(grafico);

            List<GraficoModel> contas = Conversor.DadosGrafico(graficoReference);
            /*var contas = new List<GraficoModel> {
                new GraficoModel() { Mes="Jan", Valor=100.2 },
                new GraficoModel() { Mes="Fev", Valor=200.5 },
                new GraficoModel() { Mes="Mar", Valor=250 },
                new GraficoModel() { Mes="Abr", Valor=300 },
                new GraficoModel() { Mes="Mai", Valor=326.47 },
                new GraficoModel() { Mes="Jun", Valor=478 },
                new GraficoModel() { Mes="Jul", Valor=450.48 },
                new GraficoModel() { Mes="Ago", Valor=300 },
                new GraficoModel() { Mes="Set", Valor=500 },
                new GraficoModel() { Mes="Out", Valor=379.26 },
                new GraficoModel() { Mes="Nov", Valor=200 },
                new GraficoModel() { Mes="Dez", Valor=300 },
                };*/

            var xMes = contas.Select(c => c.MesReferencia).ToArray();
            var yValores = contas.Select(c => new object[] { c.ValorTotal }).ToArray();

            var chart = new HC.Highcharts("chart")
                //Tipo do grafico
                .InitChart(new HC.Options.Chart { DefaultSeriesType = HC.Enums.ChartTypes.Line })
                //Titulo
                .SetTitle(new HC.Options.Title { Text = "Consumo de energia" })
                .SetSubtitle(new HC.Options.Subtitle { Text = "Historico" })
                //Valores eixo x
                .SetXAxis(new HC.Options.XAxis { Categories = xMes })
                //Valores eixo y
                .SetYAxis(new HC.Options.YAxis { Title = new HC.Options.YAxisTitle { Text = "Valor pago" } })
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
                .SetSeries(new HC.Options.Series[]
                {
                    new HC.Options.Series { Name = "Valor $", Data = new HC.Helpers.Data(yValores) }
                    //,new HC.Options.Series { Name = "Outra liha", Data = new HC.Helpers.Data(valores) }
                });

            return View(chart);
        }
    }
}
