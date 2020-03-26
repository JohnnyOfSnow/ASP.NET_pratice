using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace shoppingWeb.Models
{
    public class MyDatabase
    {
        public string connectString { get; set; }
        public MySqlConnection conn { get; set; }

        public bool AddImageData(MyImage image)
        {
            try
            {
                Connect();
                string id = Guid.NewGuid().ToString();
                string sql = @"INSERT INTO `image` (`ID`, `ImageName`, `ImageType`, `ImagePath`, `Price`)
                          VALUES (@id, @imageName, @imageType, @imagePath, @price)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                cmd.Parameters.Add("@imageName", MySqlDbType.VarChar).Value = image.fileName;
                cmd.Parameters.Add("@imageType", MySqlDbType.VarChar).Value = image.fileTyoe;
                cmd.Parameters.Add("@imagePath", MySqlDbType.VarChar).Value = image.filePath;
                cmd.Parameters.Add("@imagePath", MySqlDbType.VarChar).Value = image.price;


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

        public void Connect()
        {
            connectString = "server=127.0.0.1;port=3306;user id=root;password=910053johnny;database=mvctest;charset=utf8;";
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