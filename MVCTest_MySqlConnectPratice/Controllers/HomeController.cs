using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/**
 *  If you use Visual Studio 2019, you should download and install the following file.
 *      1.mysql-for-visualstudio-1.2.9
 *      2.mysql-connector-net-8.0.19
 *  
 *  Then, under the project name you will see "參照" rigiht click it, and left click "參照の追加".
 *  Third, in left window click the "拡張", and in middle window find "MySql.Data", and click "OK" in the lower right corner.
 *  Finally, you have to include the following using ... , so Visual Studio 2019 can link to mysql database.
 *  
 */
using MySql.Data.MySqlClient; 
using System.Data;

namespace MVCTest_MySqlConnectPratice.Controllers
{
    public class HomeController : Controller
    {
        /**
         *  Though it is public on website, so I have to eliminate the password.
         *  
         *  If you try to build this project, you should give the password value that you set in database. 
         * 
         */
        string connectString = "server=127.0.0.1;port=3306;user id=root;" +
                                "password=****;database=mvctest;charset=utf8;";
        MySqlConnection conn = new MySqlConnection();
        public ActionResult Index()
        {
            conn.ConnectionString = connectString;
            if(conn.State != ConnectionState.Open) // If database is connecting, you shouldn't connect it.
                conn.Open();
            string sql = @"INSERT INTO `city` (`Id`, `City`) VALUES
                           ('0', '基隆市'),
                           ('1', '台北市'),
                           ('2', '新北市'),
                           ('3', '桃園市'),
                           ('4', '新竹市'),
                           ('5', '新竹縣'),
                           ('6', '宜蘭縣'),
                           ('7', '苗栗縣'),
                           ('8', '台中市'),
                           ('9', '彰化縣'),
                           ('A', '南投縣'),
                           ('B', '雲林縣'),
                           ('C', '嘉義市'),
                           ('D', '嘉義縣'),
                           ('E', '台南市'),
                           ('F', '高雄市'),
                           ('G', '屏東縣'),
                           ('H', '澎湖縣'),
                           ('I', '花蓮縣'),
                           ('J', '台東縣'),
                           ('K', '金門縣'),
                           ('L', '連江縣');
";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            /**
             *  Insert, Revise, Delete data in database,
             *  when it is fail the "ExecuteNonQuery()" will return 0.
             */
            int index = cmd.ExecuteNonQuery();  
            bool success = false;
            if (index > 0)
                success = true;
            else
                success = false;
            ViewBag.Success = success; // Show the result in index.cshtml.
            conn.Clone(); // Close the database connection.
            return View();
        }

    }
}