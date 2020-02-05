using System;
using MVCTest_ReceiveDataByPOST.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest_ReceiveDataByPOST.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DateTime date = DateTime.Now;
            ViewBag.Date = date;
            Student student = new Student("1", "海風", 99);
            return View(student);
        }

        /**
         * 
         *  [HttpPost] should be put in methode header's upper that it talks MVC we use POST to receive data.
         * 
         *  Parameter "FormCollection post" can let us use id property which is defined in form. 
         * 
         */

        
        [HttpPost]
        public ActionResult Transcripts(FormCollection post)
        {
            string id = post["studentId"]; // Had defined an id "studentId" in index.cshtml.
            string name = post["name"]; // Had defined an id "name" in index.cshtml.
            int score = Convert.ToInt32(post["score"]); // string to integer
            Student data = new Student(id, name, score);
            return View(data);
        }
        

    }
}