using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _29_DistinctPowers
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<BigInteger> powers = new HashSet<BigInteger>();
            for (int i = 2; i <= 100; i++)
            {
                for (int j = 2; j <= 100; j++)
                {
                    powers.Add(BigInteger.Pow(i,j));
                }
            }
            Console.WriteLine(powers.Count);
            Console.ReadKey();
        }
    }
}
