using System.Web;
using System.Web.Mvc;

namespace Analise_E_Simulacao_Tarifacao_Energia
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
