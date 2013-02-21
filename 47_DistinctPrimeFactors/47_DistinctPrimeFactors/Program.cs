using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;
using SharpBag;
using System.Numerics;
using SharpBag.Strings;

namespace _47_DistinctPrimeFactors
{
    class Program
    {
        static void Main(string[] args) 
        {
            int limit = 4;

            int c = 1;
            int i = 2 * 3 * 5 * 7;
            while (c < limit)
            {
                i++;
                if (i.PrimeFactors().Distinct().Count() >= limit)
                    c++;
                else
                    c = 0;
            }
            Console.WriteLine(i - 3);
            Console.ReadKey();
        }
    }
}
