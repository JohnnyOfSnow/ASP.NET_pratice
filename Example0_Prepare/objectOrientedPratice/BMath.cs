using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace objectOrientedPratice
{
    public class BMath:AMath // Bmath inherit AMath
    {
        public int getMax(int[] num)
        {
            int max = num[0];
            for(int i = 1; i < num.Length; i++)
            {
                if(num[i] > max)
                {
                    max = num[i];
                }
            }
            return max;
        }
    }
}