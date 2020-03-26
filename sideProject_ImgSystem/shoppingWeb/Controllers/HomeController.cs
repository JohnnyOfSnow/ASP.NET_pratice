using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using shoppingWeb.Models;

namespace shoppingWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Product()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Product(FormCollection post)
        {
            string fname = post["inputFileName"];
            string froute = post["inputFileRoute"];
            int price = Convert.ToInt32(post["price"]);
            MyImage img = new MyImage(fname, froute, price);
            return View(img);      
        }
    }
}