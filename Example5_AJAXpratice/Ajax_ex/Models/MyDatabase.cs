using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/* if you want to connect sql database, you should include the following two.*/
using MySql.Data.MySqlClient;
using System.Data;

namespace Ajax_ex.Models
{
    public class MyDatabase
    {
        public string connectString { get; set; }

        public MySqlConnection conn { get; set; }
        public List<City> GetCityList()
        {
            try
            {
                bool isConnect = Connect();
                if (isConnect)
                {

                }
                return null;
            }catch(Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
            finally
            {
                Disconnect();
            }
        }

        public bool Connect()
        {
            connectString = "server=127.0.0.1;port=3306;user id=root;password=****;database=nvctest;charset=utf8;";

            conn = new MySqlConnection();

            conn.ConnectionString = connectString;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                return true;
            }
            return false;
        }

        public void Disconnect()
        {
            conn.Close();
        }
    }
}