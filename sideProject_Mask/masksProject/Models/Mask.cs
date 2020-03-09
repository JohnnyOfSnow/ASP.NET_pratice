using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace masksProject.Models
{
    /* According to JSON file, and define the correspond of class. */
    public class Mask
    {
        public string type { get; set; }
        public Features[] features { get; set; }

        public class Features
        {
            public string type { get; set; }
            public Properties properties { get; set; }
            public Geometry geometry { get; set; }

        }
        public class Properties
        {
            public string id { get; set; }
            public string name { get; set; }
            public string phone { get; set; }
            public string address { get; set; }
            public int mask_adult { get; set; }
            public int mask_child { get; set; }
            public string updated { get; set; }
            public string available { get; set; }
            public string note { get; set; }
            public string custom_note { get; set; }
            public string website { get; set; }
            public string county { get; set; }
            public string town { get; set; }
            public string cunli { get; set; }
            public string service_periods { get; set; }
        }
        public class Geometry
        {
            public string type { get; set; }
            public List<double> coordinates { get; set; }
        }
    }
}
