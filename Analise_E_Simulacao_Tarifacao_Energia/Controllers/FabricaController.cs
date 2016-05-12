using Analise_E_Simulacao_Tarifacao_Energia.Models;
using Analise_E_Simulacao_Tarifacao_Energia.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace Analise_E_Simulacao_Tarifacao_Energia.Controllers
{
    public class FabricaController : Controller
    {
        // GET: Fabrica
        [VerificaAutenticacao]
        public ActionResult List()
        {
            List<FabricaModel> ListaFabrica = new List<FabricaModel>();
            UsuarioModel usuario = Session["usuario"] as UsuarioModel;
            Session["IdFabrica"] = null;
            if (usuario != null)
            {
                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    List<ServiceReference1.Fabrica> listaDeEntrada = client.TodasFabricas(usuario.ClienteID).ToList();
                    ListaFabrica = Conversor.ListaFabricas(listaDeEntrada);
                }
            }
            return View(ListaFabrica);
        }

        // GET: Fabrica/Details/5
        [VerificaAutenticacao]
        public ActionResult Details(int id)
        {
            FabricaModel fabricaModelo = new FabricaModel();
            using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
            {
                ServiceReference1.Fabrica fabricaEntrada = client.DestalhesDaFabrica(id);
                fabricaModelo = Conversor.FabricaRecebida(fabricaEntrada);

            }
            return View(fabricaModelo);
        }

        // GET: Fabrica/Create
        [VerificaAutenticacao]
        public ActionResult Create()
        {
            FabricaModel fabricaModelo = new FabricaModel();
            return View(fabricaModelo);
        }

        // POST: Fabrica/Create
        [HttpPost]
        public ActionResult Create(FabricaModel modeloFabrica)
        {
            try
            {
                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    ServiceReference1.Fabrica fabrica = Conversor.NovaFabrica(modeloFabrica);
                    bool resultado = client.CadastrarFabrica(fabrica);
                    if (resultado)
                    {
                        TempData["CadastrarFabrica"] = true;
                        return RedirectToAction("List");
                    }
                    else
                    {
                        throw new InvalidOperationException("O Serviço não pode cadastrar o Objeto. Verifique se o mesmo encontra-se preenchido corretamente");
                    }
                }
            }
            catch(Exception ex)
            {
                ViewBag.CadastrarFabrica = false;
                ViewBag.ErroCadastrarFabrica = ex.Message;
                return View();
            }
        }

        // GET: Fabrica/Edit/5
        [VerificaAutenticacao]
        public ActionResult Edit(int id)
        {
            FabricaModel fabricaModelo = new FabricaModel();
            using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
            {
                ServiceReference1.Fabrica fabricaEntrada = client.DestalhesDaFabrica(id);
                fabricaModelo = Conversor.FabricaRecebida(fabricaEntrada);

            }
            return View(fabricaModelo);
        }

        // POST: Fabrica/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FabricaModel modeloFabrica)
        {
            try
            {
                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    ServiceReference1.Fabrica fabrica = Conversor.AlterarFabrica(modeloFabrica);
                    bool resultado = client.AtualizarFabrica(fabrica);
                    if (resultado)
                    {
                        TempData["AtualizarFabrica"] = true;
                        return RedirectToAction("List");
                    }
                    else
                    {
                        throw new InvalidOperationException("O Serviço não pode atualizar o Objeto. Verifique se o mesmo encontra-se preenchido corretamente");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.AtualizarFabrica = false;
                ViewBag.ErroAtualizarFabrica = ex.Message;
                return View();
            }
        }

        // GET: Fabrica/Delete/5
        [VerificaAutenticacao]
        public ActionResult Delete(int id)
        {
            FabricaModel fabricaModelo = new FabricaModel();
            using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
            {
                ServiceReference1.Fabrica fabricaEntrada = client.DestalhesDaFabrica(id);
                fabricaModelo = Conversor.FabricaRecebida(fabricaEntrada);

            }
            return View(fabricaModelo);
        }

        // POST: Fabrica/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FabricaModel modeloFabrica)
        {
            try
            {
                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    ServiceReference1.Fabrica fabrica = Conversor.ExcluirFabrica(modeloFabrica);
                    bool resultado = client.DeletarFabrica(fabrica);
                    if (resultado)
                    {
                        TempData["DeletarFabrica"] = true;
                        return RedirectToAction("List");
                    }
                    else
                    {
                        throw new InvalidOperationException("O Serviço não pode Excluir o Objeto");
                    }
                }
            }
            catch(Exception ex)
            {
                ViewBag.DeletarFabrica = false;
                ViewBag.ErroDeletarFabrica = ex.Message;
                return View();
            }
        }
    }
}
