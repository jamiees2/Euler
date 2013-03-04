using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;
using SharpBag.Math.ForBigInteger;
using System.Numerics;

namespace _65_ConvergentsOfE
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperbound = 100;
            int result = 0;

            BigInteger d = 1;
            BigInteger n = 2;

            for (int i = 2; i <= upperbound; i++)
            {
                BigInteger temp = d;
                int c = (i % 3 == 0) ? 2 * (i / 3) : 1;
                d = n;
                n = c * d + temp;
            }
            result = n.Digits().Sum();
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
