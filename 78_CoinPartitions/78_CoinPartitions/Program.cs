using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _78_CoinPartitions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(p(1,5));
            var p = new List<int>();
            var n = 1;
            p.Add(1);
            while(true)
            {
                int i = 0;
                int penta = 1;
                p.Add(0);
                while (penta <= n)
                {
                    var sign = (i%4 > 1) ? -1 : 1;
                    p[n] += sign*p[n - penta];
                    p[n] %= 1000000;

                    i++;
                    int j = (i%2 == 0) ? i/2 + 1 : -(i/2 + 1);
                    penta = j*(3*j - 1)/2;
                }
                if (p[n] == 0) break;
                n++;
            }
            Console.WriteLine(n);
            Console.ReadKey();
        }

        static Dictionary<Tuple<int,int>,BigInteger> cache = new Dictionary<Tuple<int,int>,BigInteger>(); 
        static BigInteger p(int k, int n)
        {
            if (k > n)
            {
                return 0;
            }
            if (k == n)
            {
                return 1;
            }
            var key = new Tuple<int, int>(k, n);
            if (cache.ContainsKey(key)) return cache[key];
            cache[key] = (p(k + 1, n) + p(k, n - k)) % 1000000;
            return cache[key];
        }
    }
}
