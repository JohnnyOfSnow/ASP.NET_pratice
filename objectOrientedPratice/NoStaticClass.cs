using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace objectOrientedPratice
{
    public class NoStaticClass
    {
        private int _id; //column

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public void Method()
        {
            ID = ID * 10;
        }

    }
}