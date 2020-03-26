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
            string fpath = post["inputFilePath"];
            int price = Convert.ToInt32(post["price"]);
            string ftype = "";
            MyImage img = new MyImage();
            img.getFileType(fpath);

            return View(img);      
        }
    }
}