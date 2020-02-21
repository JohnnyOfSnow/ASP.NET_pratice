using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ajax_ex.Models;
using Newtonsoft.Json;

namespace Ajax_ex.Controllers
{
    public class HomeController : Controller
    {

        MyDatabase db = new MyDatabase();
        public ActionResult Index()
        {
            List<City> cityList = db.GetCityList();

            ViewBag.CityList = cityList;
            return View();
        } 

        [HttpPost]
        public ActionResult Village(string id="")
        {
            List<Village> villageList = db.GetVillageList(id);
            string result = "";
            if(villageList == null)
            {
                return Json(result);
            }
            else
            {
                result = JsonConvert.SerializeObject(villageList);
                return Json(result);
            }
        }
    }
}