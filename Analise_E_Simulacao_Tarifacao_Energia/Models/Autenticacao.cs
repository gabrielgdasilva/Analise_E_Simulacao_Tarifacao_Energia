using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Analise_E_Simulacao_Tarifacao_Energia.Models
{
    public class Autenticacao : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var autorizado = base.AuthorizeCore(httpContext);
            if (!autorizado)
            {
                return false;
            }

            var usuario = httpContext.Session["usuario"];
            if(usuario == null)
            {
                return false;
            }

            return true;
        }

        
    }
}
