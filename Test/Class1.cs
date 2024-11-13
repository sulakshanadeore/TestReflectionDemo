using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Calculator
    {
        public Calculator() 
        {
        }
        
        private double _number;
        public double Number { get { return _number; } set { _number = value; } }
        public void Clear()
        {
            _number = 0;
        }
        public double Add(double number)
        {
            double ans = number + number;
            return ans;
        }
        private static double _pi = 3.14d;
        public static double Pi
        {
            get { return _pi; }
        }

    }

}
