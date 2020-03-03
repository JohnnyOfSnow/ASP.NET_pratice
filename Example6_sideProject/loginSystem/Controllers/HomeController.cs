using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using loginSystem.Models;
using Newtonsoft.Json;

namespace loginSystem.Controllers
{
    public class HomeController : Controller
    {
        MyDataBase db = new MyDataBase();
        public ActionResult Index()
        {
            List<City> cityList = db.getCityList();
            List<Village> villageList = new List<Village>();

            ViewBag.CityList = cityList;
            ViewBag.VillageList = villageList;
            return View(new userData());
        }

        [HttpPost]
        public ActionResult Index(userData data)
        {
            // wrong data judgement
           if(string.IsNullOrWhiteSpace(data.password1) || data.password1 != data.password2)
           {
                List<City> cityList = db.getCityList();
                List<Village> villageList = new List<Village>();
                if (!string.IsNullOrWhiteSpace(data.city))
                    villageList = db.getVillageList(data.city);
                ViewBag.CityList = cityList;
                ViewBag.VillageList = villageList;
                ViewBag.Msg = "密碼輸入錯誤";
                return View(data);


            }
            else 
            {
                if (db.AddUserData(data))
                {
                    //return RedirectToAction("Login");
                    Response.Redirect("~/Home/Login");
                    return new EmptyResult();
                }
                else
                {
                    ViewBag.Msg = "註冊失敗...";
                    return View(data);
                }
            }
        }
        
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection post)
        {
            string account = post["account"];
            string password = post["password"];

            if(db.CheckUserData(account, password))
            {
                ViewBag.Msg = "登入成功";
                Session["account"] = account; // Create a session
                Response.Redirect("~/Home/Home");
                return new EmptyResult();
            }
            else{
                ViewBag.Msg = "登入失敗";
            }
            return View();
        }

        [HttpPost]
       public ActionResult Village(string id="")
       {
            List<Village> villageList = db.getVillageList(id);
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