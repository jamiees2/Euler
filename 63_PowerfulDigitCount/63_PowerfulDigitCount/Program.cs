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

            int digits = 0;
            int i = 2;
            while (BigInteger.Pow(2,i).ToString().Length <= i)
            {
                BigInteger n = 0;
                int j = 2;
                while (digits <= i)
                {
                    n = BigInteger.Pow(j, i);
                    digits = n.ToString().Length;
                    if (digits == i)
                    {
                        result++;
                    }
                    j++;
                }
                i++;
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
