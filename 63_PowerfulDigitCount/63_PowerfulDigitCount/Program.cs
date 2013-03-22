using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;
using System.Numerics;

namespace _63_PowerfulDigitCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            var n = 1;
            var lower = 0;
            while (lower < 10)
            {
                lower = (int) Math.Ceiling(Math.Pow(10, (n - 1.0)/n));
                result += 10 - lower;
                n++;
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
