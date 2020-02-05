using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTest_ReceiveDataByModel.Models;

namespace MVCTest_ReceiveDataByModel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DateTime date = DateTime.Now;
            ViewBag.Date = date;
            Student student = new Student("1", "海風", 99);
            return View(student); // Go to index.cshtml
        }

        /**
         *  To receive data by Model, frontend's control element of value should have @Model.(...). 
         * 
         *  If you use POST method passing data, you should add [HttpPost] in the method header's upper
         */

        [HttpPost]
        public ActionResult Transcripts(Student model)
        {
            string id = model.id; // frontend control element  <input type="text"value="@Model.id" /> 
            string name = model.name; // frontend control element  <input type="text"value="@Model.name" /> 
            int score = model.score; // frontend control element  <input type="text"value="@Model.score" /> 
            Student data = new Student(id, name, score);
            return View(data); // Go to Transcripts.cshtml
        }
        
    }
}