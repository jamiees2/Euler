using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _45_TriangluarPentagonalHexagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            long result = 0;
            //Each hexagonal number is also triangular
            int i = 143;
            while (true)
            {
                i++;
                result = i * (2 * i - 1);
                if (IsPentagonal(result))
                {
                    Console.WriteLine(result);
                    break;
                }
            }
            Console.ReadKey();
        }
        static bool IsPentagonal(long n) 
        {
            //n = sqrt(24x+1)+1 / 6
            return ((Math.Sqrt(24 * n + 1) + 1) / 6) % 1 == 0;
        }

        static HashSet<BigInteger> CalculateNPentagonals(int limit)
        {
            HashSet<BigInteger> ret = new HashSet<BigInteger>();
            for (int i = 1; i <= limit; i++)
            {
                ret.Add((i * ((3 * i) - 1)) / 2);
            }
            return ret;
        }
        static HashSet<BigInteger> CalculateNTriangulars(int limit)
        {
            HashSet<BigInteger> ret = new HashSet<BigInteger>();
            for (int i = 1; i <= limit; i++)
            {
                ret.Add((i * (i + 1)) / 2);
            }
            return ret;
        }
        static HashSet<BigInteger> CalculateNHexagonals(int limit)
        {
            HashSet<BigInteger> ret = new HashSet<BigInteger>();
            for (int i = 1; i <= limit; i++)
            {
                ret.Add(i * ((2 * i) - 1));
            }
            return ret;
        }
    }
}
