using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajax_ex.Models
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

        public Village(string _CityId, string _CityName, string _VillageId, string _VillageName)
        {
            CityId = _CityId;
            CityName = _CityName;
            VillageId = _VillageId;
            VillageName = _VillageName;
        }

        public override string ToString()
        {
            return "";
        }
    }
}