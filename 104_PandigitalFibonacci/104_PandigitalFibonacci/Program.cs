using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;
using System.Numerics;

namespace _104_PandigitalFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 10;
            string fibStringStart = null, fibStringEnd = null;
            while (true)
            {
                string temp = fib(i).ToString();
                
                if (temp.Length > 9)
                {
                    fibStringStart = temp.Substring(0, 9);
                    fibStringEnd = temp.Substring(temp.Length - 10);
                    if (IsPandigital(fibStringStart))
                    {
                        if (IsPandigital(fibStringEnd))
                        {
                            break;
                        }
                    }
                }
                i++;
            }
            Console.WriteLine(i);
            Console.ReadKey();
        }

        static bool IsPandigital(string nString)
        {
            if (nString == null || nString.Length != 9)
            {
                return false;
            }
            for (int i = 1; i < 10; i++)
            {
                if (nString.Count(x => x.ToString() == i.ToString()) != 1) return false;
            }
            if (nString.Length > 9) return false;
            return true;
        }

        static Dictionary<BigInteger, BigInteger> cache = new Dictionary<BigInteger, BigInteger>();
        static BigInteger fib(BigInteger n) 
        {
            if (cache.Count == 0)
            {
                cache.Add(0, 0);
                cache.Add(1, 1);
                cache.Add(2, 1);
            }
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            BigInteger f = fib(n - 1) + fib(n - 2);
            cache.Add(n, f);
            return f;
        }
    }
}
