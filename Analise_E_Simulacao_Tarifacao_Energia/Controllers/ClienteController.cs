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
        // GET: Cliente/Details/5
        [VerificaAutenticacao]
        public ActionResult Details()
        {
            try
            {
                UsuarioModel login = Session["usuario"] as UsuarioModel;
                ClienteModel clienteModelo = new ClienteModel();

                using (ServiceReference1.TEE_BUS_Service1Client client = new ServiceReference1.TEE_BUS_Service1Client())
                {
                    ServiceReference1.Cliente clienteEntrada = client.DetalhesCliente(login.ClienteID);
                    clienteModelo = Conversor.ClienteRecebido(clienteEntrada);
                }

                return View(clienteModelo);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Erro", new { area = "" });
            }
        }
    }
}