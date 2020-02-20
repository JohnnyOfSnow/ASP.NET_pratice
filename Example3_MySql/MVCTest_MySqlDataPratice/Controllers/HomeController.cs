using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace MVCTest_MySqlDataPratice.Controllers
{
    public class HomeController : Controller
    {
        string connString = "server=127.0.0.1;port=3306;user id=root;password=910053johnny;database=mvctest;charset=utf8;";
        MySqlConnection conn = new MySqlConnection();
        public ActionResult Index()
        {
            conn.ConnectionString = connString;
            if (conn.State != ConnectionState.Open)
                conn.Open();
            string sql = @"INSERT INTO Village (CityId,City,VillageId,Village) VALUES
                           ('0','基隆市','001','中正區');
";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int index = cmd.ExecuteNonQuery();
            bool success = false;
            if (index > 0)
                success = true;
            else
                success = false;
            ViewBag.Success = success;
            conn.Close();
            return View();
        }

       
    }
}