using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Analise_E_Simulacao_Tarifacao_Energia.Utilities
{
    class VerificaAutenticacao : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["usuario"] == null)
            {
                filterContext.Result = new RedirectResult("/");
            }
        }
    }
}
