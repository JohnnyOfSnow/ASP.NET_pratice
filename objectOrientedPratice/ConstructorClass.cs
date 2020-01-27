using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace objectOrientedPratice
{
    public class ConstructorClass
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public ConstructorClass(int id)
        {
            ID = id * 10;
        }
    }
}