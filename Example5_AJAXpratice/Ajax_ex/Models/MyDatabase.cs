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
                Connect();                   
                string sql = @" SELECT `Id`, `CityName` FROM `city`";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                List<City> list = new List<City>();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        City city = new City();
                        city.Id = dr["Id"].ToString();
                        city.CityName = dr["CityName"].ToString();
                        list.Add(city);
                    }
                }
                return list;
                
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

        public List<Village> GetVillageList(string id)
        {
            try
            {
                Connect();
                string sql = @" SELECT `CityId`,`VillageId`, `VillageName` FROM `Village`";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                List<Village> list = new List<Village>();

                int villageCount = 0;

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if(id.Equals(dr["CityId"].ToString()))
                        {
                            Village data = new Village();
                            data.VillageId = dr["VillageId"].ToString();
                            data.VillageName = dr["VillageName"].ToString();
                            list.Add(data);
                        }       
                    }
                }
                return list;

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


        public void Connect()
        {
            connectString = "server=127.0.0.1;port=3306;user id=root;password=****;database=mvctest;charset=utf8;";

            conn = new MySqlConnection();

            conn.ConnectionString = connectString;
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }

        public void Disconnect()
        {
            conn.Close();
        }
    }
}