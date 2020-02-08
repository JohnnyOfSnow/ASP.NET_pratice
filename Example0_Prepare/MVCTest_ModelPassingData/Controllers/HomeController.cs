using MVCTest_ModelPassingData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest_ModelPassingData.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            DateTime date = DateTime.Now;
            ViewBag.Date = date;

            Student student = new Student("1", "小明", 80);
            return View(student);
        }

    }
}