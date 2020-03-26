using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingWeb.Models
{
    public class MyImage
    {
        public string fileName { get; set; }
        public string fileRoute { get; set; }
        public int price { get; set; }

        public MyImage()
        {
            fileName = "";
            fileRoute = "";
            price = 0;
        }

        public MyImage(string _fileName, string _fileRoute, int _price)
        {
            fileName = _fileName;
            fileRoute = _fileRoute;
            price = _price;
        }


    }
}