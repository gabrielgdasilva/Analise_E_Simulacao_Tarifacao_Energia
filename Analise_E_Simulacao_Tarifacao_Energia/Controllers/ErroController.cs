using Analise_E_Simulacao_Tarifacao_Energia.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analise_E_Simulacao_Tarifacao_Energia.Controllers
{
    public class ErroController : Controller
    {
        // GET: Erro
        [VerificaAutenticacao]
        public ActionResult Index()
        {
            return View();
        }
    }
}