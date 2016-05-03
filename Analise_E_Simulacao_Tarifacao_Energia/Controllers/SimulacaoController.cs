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
    }
}
