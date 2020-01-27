using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace objectOrientedPratice
{
    public class AMath
    {
        public int getMax(int n1, int n2)
        {
            if(n1 > n2)
            {
                return n1;
            }
            else
            {
                return n2;
            } 
        }
    }
}