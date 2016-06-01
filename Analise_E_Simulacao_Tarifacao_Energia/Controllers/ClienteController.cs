using Analise_E_Simulacao_Tarifacao_Energia.Models;
using Analise_E_Simulacao_Tarifacao_Energia.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analise_E_Simulacao_Tarifacao_Energia.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        [VerificaAutenticacao]
        public ActionResult Index(int id)
        {
            using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
            {
                ServiceReference1.Cliente sCliente = client.DetalhesCliente(id);
                ClienteModel clienteModelo = Conversor.ClienteRecebido(sCliente);

                return View(clienteModelo);
            }
            
        }

        // GET: Cliente/Details/5
        [VerificaAutenticacao]
        public ActionResult Details()
        {
            UsuarioModel login = Session["usuario"] as UsuarioModel;
            ClienteModel clienteModelo = new ClienteModel();

            using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
            {
                ServiceReference1.Cliente clienteEntrada = client.DetalhesCliente(login.ClienteID);
                clienteModelo = Conversor.ClienteRecebido(clienteEntrada);
            }

            return View(clienteModelo);
        }

        // GET: Cliente/Create
        [VerificaAutenticacao]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        [VerificaAutenticacao]
        public ActionResult Edit(int id)
        {
            using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
            {
                ServiceReference1.Cliente sCliente = client.DetalhesCliente(id);
                ClienteModel _Cliente = Conversor.ClienteRecebido(sCliente);

                return View(_Cliente);
            }
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ClienteModel model)
        {
            try
            {
                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    ServiceReference1.Cliente sCliente = Conversor.AtualizarCliente(model);
                    bool resultado = client.AtualizarCliente(sCliente);
                    if (resultado)
                    {
                        TempData["AtualizarCliente"] = true;
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        throw new InvalidOperationException("O Serviço não pode cadastrar o Objeto. Verifique se o mesmo encontra-se preenchido corretamente.");
                    }
                }
            }
            catch(Exception ex)
            {
                ViewBag.AtualizarCliente = false;
                ViewBag.ErroAtualizarCliente = ex.Message;
                return View();
            }
        }

        // GET: Cliente/Delete/5
        [VerificaAutenticacao]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
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
