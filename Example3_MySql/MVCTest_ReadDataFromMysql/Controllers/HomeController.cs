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
using System.Data;
using MySql.Data.MySqlClient;

namespace MVCTest_ReadDataFromMysql.Controllers
{
    public class HomeController : Controller
    {
        /**
        *  Though it is public on website, so I have to eliminate the password.
        *  
        *  If you try to build this project, you should give the password value that you set in database. 
        * 
        */
        string connectString = "server=127.0.0.1;port=3306;user id=root;password=****;database=mvctest; charset = utf8;";
        MySqlConnection conn = new MySqlConnection();
        public ActionResult Index()
        {
            conn.ConnectionString = connectString;
            string sql = @" SELECT `Id`, `City` FROM `city`"; // @" SELECT `欄位1`, `欄位2` FROM `表格名稱`"

            DataTable dt = new DataTable(); // Prepare a DataTable to receive a table from database.
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn); // MySqlDataAdapter can handle connecting and disconnecting
            adapter.Fill(dt);

            /**
             *  物件dt取資料的方法:
             *  
             *  dt.Rows[0]["Id"] = 0 ; dt.Rows[0]["City"] = 基隆市
             *  dt.Rows[1]["Id"] = 1 ; dt.Rows[1]["City"] = 台北市
             *  .
             *  .
             *  .
             *  dt.Rows[i]["Id"] = 第i個的Id ; dt.Rows[i]["City"] = 第i個的City名稱
             * 
             */

            ViewBag.DT = dt; // pass object(dt) to frontend(index.cshtml).
            return View();
        }    
    }
}