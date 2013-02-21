using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;
using SharpBag.Strings;

namespace _74_DigitFactorialChains
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> starting = new List<int>();
            int maxCount = 60 - 1;
            for (int i = 1; i < 1000000; i++)
            {
                int next = i.Digits().Select(fact).Sum();
                int count = 1;
                HashSet<int> repeats = new HashSet<int>();
                while (next != i)
                {
                    next = next.Digits().Select(fact).Sum();
                    if (repeats.Contains(next))
                    {
                        break;
                    }
                    repeats.Add(next);
                    count++;
                }
                if(count >= maxCount)
                {
                    starting.Add(i);
                    maxCount = count;
                }
            }
            Console.WriteLine(starting.ToStringPretty() + "\n" + maxCount + "\n" + starting.Count);
            Console.ReadKey();
        }

        static Dictionary<int, int> cache = new Dictionary<int, int>();
        static int fact(int n)
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
                int fac = n * fact(n - 1);
                cache.Add(n, fac);
                return fac;
            }
        }
    }
}
