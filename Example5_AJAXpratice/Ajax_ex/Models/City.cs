using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajax_ex.Models
{
    public class City
    {
        public string Id { get; set; }
        public string CityName { get; set; }

        public City()
        {
            Id = string.Empty;
            CityName = string.Empty;
        }

        public City(string _id, string _city)
        {
            Id = _id;
            CityName = _city;
        }

        public override string ToString()
        {
            return "";
        }
    }
}