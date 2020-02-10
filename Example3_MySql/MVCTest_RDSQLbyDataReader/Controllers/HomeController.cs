using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using MySql.Data.MySqlClient;
using MVCTest_RDSQLbyDataReader.Models;

namespace MVCTest_RDSQLbyDataReader.Controllers
{
    public class HomeController : Controller
    {
        /**
        *  Though it is public on website, so I have to eliminate the password.
        *  
        *  If you try to build this project, you should give the password value that you set in database. 
        * 
        */
        string connectString = "server=127.0.0.1;port=3306;user id=root;password=****;database=mvctest;charset=utf8;";
        MySqlConnection conn = new MySqlConnection();
        public ActionResult Index()
        {
            conn.ConnectionString = connectString;
            string sql = @" SELECT `Id`, `City` FROM `city`"; // @" SELECT `欄位1`, `欄位2` FROM `表格名稱`"
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            List<City> list = new List<City>();

            if (conn.State != ConnectionState.Open) // If database is connecting, you shouldn't connect it.
                conn.Open();

            /*
             *  Use MySqlDataReader to read data, you should use cmd.ExecuteReader.
             *  
             *  Data can put in Model which is defined in class(e.g. City.cs in Model folder).
             * 
             */
            using (MySqlDataReader dr = cmd.ExecuteReader()) {
                while (dr.Read())
                {
                    City city = new City(); // Defined in Model folder. 
                    city.CityId = dr["Id"].ToString();
                    city.CityName = dr["City"].ToString();
                    list.Add(city);
                }
            }

            if (conn.State != ConnectionState.Closed) // Remember to disconnection database.
                conn.Close();

            ViewBag.List = list; // Send list(database's data) to frontend.

            return View();
        }
    }
}