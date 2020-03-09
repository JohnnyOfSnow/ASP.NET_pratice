using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using masksProject.Models;
using Newtonsoft.Json;

namespace masksProject.Controllers
{
    public class HomeController : Controller
    {
        MyDatabase db = new MyDatabase();
        List<Village> villageList;
        List<City> cityList;
        MyMaskSearch myMaskSearch;

        public ActionResult Index()
        {
            cityList = db.getCityList();
            villageList = new List<Village>();
            
            ViewBag.CityList = cityList;
            ViewBag.VillageList = villageList;
            return View();
        }

        [HttpPost]
        public ActionResult Village(string id = "")
        {
            List<Village> villageList = db.getVillageList(id);
            string result = "";
            if (villageList == null)
            {
                return Json(result);
            }
            else
            {
                result = JsonConvert.SerializeObject(villageList);
                return Json(result);
            }
        }

        [HttpPost]
        public ActionResult CountryName(string countryName = "")
        {
            MyMaskSearch myMaskSearch = new MyMaskSearch();
            List<selfMask> maskList = myMaskSearch.getCoutry(countryName);
            string result = "";
            if (maskList == null)
            {
                return Json(result);
            }
            else
            {
                result = JsonConvert.SerializeObject(maskList);
                return Json(result);
            }
        }
    }
}