using System.Web;
using System.Web.Mvc;

namespace MVCTest_MySqlDataPratice
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
