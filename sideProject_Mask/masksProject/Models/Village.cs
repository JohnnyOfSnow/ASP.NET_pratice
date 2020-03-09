using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace masksProject.Models
{
    public class Village
    {
        public string CityId { get; set; }
        public string CityName { get; set; }
        public string VillageId { get; set; }
        public string VillageName { get; set; }

        public Village()
        {
            CityId = string.Empty;
            CityName = string.Empty;
            VillageId = string.Empty;
            VillageName = string.Empty;
        }
    }
}