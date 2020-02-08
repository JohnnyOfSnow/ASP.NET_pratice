using System.Web;
using System.Web.Mvc;

namespace MVCTest_ReadDataFromMysql
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
