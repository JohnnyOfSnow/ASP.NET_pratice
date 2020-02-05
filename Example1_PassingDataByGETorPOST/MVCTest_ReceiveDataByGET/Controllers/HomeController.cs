using System;
using MVCTest_ReceiveDataByGET.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest_ReceiveDataByGET.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DateTime date = DateTime.Now;
            ViewBag.date = date;

            Student data = new Student("U10715302", "小明", 99);

            return View(data);
        }

        /**
         *  When user submit form's data, the following method is triggered. 
         * 
         *  Compare the every control element's name property to pass the parameter,
         *  So, you should have id, name, score's name property definition (index.cshtml).
         * 
         */
        public ActionResult Transcripts(string id, string name, int score)
        {
            Student data = new Student(id, name, score);
            return View(data);
        }

       
    }
}