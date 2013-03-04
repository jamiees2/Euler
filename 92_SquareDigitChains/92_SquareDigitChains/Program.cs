using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;

namespace _92_SquareDigitChains
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            for (int i = 1; i < 10000000; i++)
            {
                if (chain(i) == 89)
                {
                    result++;
                }
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }

        static Dictionary<int, int> cache = new Dictionary<int, int>();
        static int chain(int n)
        {
            if (cache.Count == 0)
            {
                cache.Add(1, 1);
                cache.Add(89, 89);
            }
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }
            int c = chain(n.Digits().Select(x => (int)Math.Pow(x, 2)).Sum());
            cache.Add(n, c);
            return c;
        }
    }
}
