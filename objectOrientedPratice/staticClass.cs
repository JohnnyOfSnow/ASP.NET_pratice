using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace objectOrientedPratice
{
    public static class StaticClass
    {
        private static int _id;

        public static int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public static void Method()
        {
            ID = ID * 10;
        }

    }
}