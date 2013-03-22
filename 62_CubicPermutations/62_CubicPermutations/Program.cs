using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using SharpBag.Math;
using SharpBag.Strings;

namespace _62_CubicPermutations
{
    class Program
    {
        static void Main(string[] args)
        {
            var cubes = new HashSet<BigInteger>();
            for (int i = 4000; i < 10000; i++)
            {
                cubes.Add(BigInteger.Pow(i, 3));
            }
            foreach (var bigInteger in cubes)
            {
                var list = cubes.Where(x => IsPermutation(x, bigInteger)).ToList();
                if (list.Count == 5)
                {
                    Console.WriteLine(bigInteger);
                    //Console.WriteLine(BigInteger.Pow.Pow(bigInteger,1/3.0));
                    //Console.WriteLine(list.ToStringPretty());
                    //Console.WriteLine(list.Select(x => Math.Pow((int) x, 1/3.0)).ToStringPretty());
                    break;
                }
            }
            Console.ReadKey();
        }

        static bool IsPermutation(BigInteger n1, BigInteger n2)
        {
            string n = n1.ToString(), m = n2.ToString();
            return n.Length == m.Length && n.Distinct().All(c => m.Count(x => x == c) == n.Count(x => x == c));
        }

    }
}
