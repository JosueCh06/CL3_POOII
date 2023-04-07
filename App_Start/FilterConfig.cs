using System.Web;
using System.Web.Mvc;

namespace CL3_POOII_JosueDanielChupicaInga
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
