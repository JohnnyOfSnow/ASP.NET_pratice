using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace masksProject.Models
{
    public class City
    {
        public string CityId { get; set; }
        public string CityName { get; set; }

        public City()
        {
            CityId = string.Empty;
            CityName = string.Empty;
        }
    }
}