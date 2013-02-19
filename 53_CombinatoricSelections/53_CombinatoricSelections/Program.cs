using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _53_CombinatoricSelections
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int count = 0;
            for (int n = 1; n <= 100; n++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (C(n,k) > 1000000)
                    {
                        count++;
                        //Console.WriteLine("C("+n+","+k+") = " + C(n,k));
                        //break;
                    }
                }
            }
            Console.WriteLine(count);
            Console.ReadKey();
        }

        static BigInteger C(int n, int k) 
        {
            if (k > n) throw new ArgumentException("k");
            if (n == k || k <= 0) return 1;
            if (k == 1) return n;
            return fact(n) / (fact(k) * fact(n - k));
        }

        static Dictionary<int, BigInteger> cache = new Dictionary<int, BigInteger>();
        static BigInteger fact(int n) 
        {
            if (cache.Count == 0)
            {
                cache.Add(0, 1);
                cache.Add(1, 1);
                cache.Add(2, 2);
            }
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }
            else
            {
                BigInteger fac = n * fact(n - 1);
                cache.Add(n, fac);
                return fac;
            }
        }
    }
}
