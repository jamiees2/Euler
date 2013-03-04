using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;
using System.Numerics;

namespace _97_LargeNonMersennePrime
{
    class Program
    {
        static void Main(string[] args)
        {
            //Silly first try ;)
            //string number = (BigInteger.Multiply(28433,BigInteger.Pow(2,7830457)) + 1).ToString();
            BigInteger power = 1;
            string str = null;
            for (int i = 0; i < 7830457; i++)
            {
                str = (power * 2).ToString();
                power = BigInteger.Parse(str.Substring(Math.Max(0, str.Length - 10)));
            }
            str = (28433 * power).ToString();
            BigInteger prime = BigInteger.Parse(str.Substring(Math.Max(0, str.Length - 10))) + 1;
            Console.WriteLine(prime);
            Console.ReadKey();
        }

    }
}
