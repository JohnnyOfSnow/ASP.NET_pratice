using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;

namespace shoppingWeb.Models
{
    public class MyImage
    {
        public string fileName { get; set; }
        public string filePath { get; set; }
        public string fileTyoe { get; set; }
        public int price { get; set; }

        public MyImage()
        {
            fileName = "";
            filePath = "";
            fileTyoe = "";
            price = 0;
        }

        public MyImage(string _fileName, string _filePath, string _fileType, int _price)
        {
            fileName = _fileName;
            filePath = _filePath;
            fileTyoe = _fileType;
            price = _price;
        }

        public void getFileType(string fpath)
        {

            // 測試抓取 Google Logo. 
                Uri uri = new Uri(fpath);
              string saveDir = @"~\obj\";    // 注意：資料夾必須已存在 
              string fileName = "google.jpg";
              string savePath = saveDir + fileName;
           
              System.Net.WebRequest request = System.Net.WebRequest.Create(uri);
              System.Net.WebResponse response = request.GetResponse();
              System.IO.Stream stream = response.GetResponseStream();
              Image img = Image.FromStream(stream);
              img.Save(savePath);

            /**
            string ft = "";
            string[] a = fpath.Split(':');
            FileInfo fi = new FileInfo(a[1]);
            string name = fi.FullName;
            string type = fi.Extension;
            if (type == ".jpg" || type == ".gif" || type == ".bmp" || type == ".png" )
            {
                string SavePath = HttpContext.Current.Server.MapPath("~\\excel");//圖片儲存到資料夾下
                string ImagePath = SavePath + "\\" + name;//儲存路徑
            }*/

        }
        
    }
}