using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace loginSystem.Models
{
    public class MyDataBase
    {
        public string connectString { get; set; }
        public MySqlConnection conn { get; set; }

        public List<City> getCityList()
        {
            try
            {
                Connect();
                string sql = @"SELECT `Id`, `CityName` from `city`";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                List<City> cities = new List<City>();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        City city = new City();
                        city.CityId = dr["Id"].ToString();
                        city.CityName = dr["CityName"].ToString();
                        cities.Add(city);

                    }
                }
                return cities;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }

            finally
            {
                Disconnect();
            }
        }
        public List<Village> getVillageList(string id)
        {
            try
            {
                Connect();
                string sql = @"SELECT `CityId`, `VillageId`, `VillageName` from `village`";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                List<Village> villages = new List<Village>();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr["CityId"].Equals(id))
                        {
                            Village village = new Village();
                            village.VillageId = dr["VillageId"].ToString();
                            village.VillageName = dr["VillageName"].ToString();
                            villages.Add(village);
                        }     
                    }
                }
                return villages;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }

            finally
            {
                Disconnect();
            }
        }

        public bool AddUserData(userData data)
        {
            try
            {
                Connect();
                string id = Guid.NewGuid().ToString();
                string sql = @"INSERT INTO `userdata` (`id`, `account`, `password`, `city`, `village`, `address`)
                          VALUES (@id, @account, @password, @city, @village, @address)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                cmd.Parameters.Add("@account", MySqlDbType.VarChar).Value = data.account;
                cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = data.password1;
                cmd.Parameters.Add("@city", MySqlDbType.VarChar).Value = data.city;
                cmd.Parameters.Add("@village", MySqlDbType.VarChar).Value = data.village;
                cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = data.address;

                cmd.ExecuteNonQuery();
                return true;

            }
            catch(Exception ex)
            {
                string error = ex.ToString();
                return false;
            }

            finally
            {
                Disconnect();
            }
        }

        public void Connect() {
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