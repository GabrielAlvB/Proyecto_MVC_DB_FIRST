using System.Web;
using System.Web.Mvc;

namespace Proyecto_MVC_DB_FIRST
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
