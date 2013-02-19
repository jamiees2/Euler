using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _46_GoldbachsConjecture
{
    class Program
    {
        static void Main(string[] args)
        {
            //If a composite can be written as the sum of a prime and 2*square, then
            //sqrt((c - p)/2) % 1 == 0 is true
            int testLimit = 10000;
            HashSet<long> primes = computePrimes(testLimit);
            IEnumerable<int> oddComposites = Enumerable.Range(3,testLimit-1).Where(x => !primes.Contains(x));
            foreach (var c in oddComposites)
            {
                bool valid = false;
                foreach (var p in primes.Where(p=>p<c))
                {
                    if (TestGoldbach(c, p))
                    {
                        valid = true;
                        break;
                    }
                }
                if (!valid)
                {
                    Console.WriteLine(c);
                    break;
                }
            }
            Console.ReadKey();
        }
        static bool TestGoldbach(int c, long p) 
        {
            return Math.Sqrt((c - p) / 2) % 1 == 0;
        }
        public static HashSet<long> computePrimes(int limit)
        {
            BitArray candidates = new BitArray(limit, true);
            HashSet<long> primes = new HashSet<long>();

            for (int i = 2; i < limit; i++)
            {
                if (candidates[i])
                {
                    for (int j = i * 2; j < limit; j += i)
                    { candidates[j] = false; }
                }
            }
            candidates[1] = false;
            for (int i = 1; i < limit; i++)
            {
                if (candidates[i])
                {
                    primes.Add(i);
                }
            }


            return primes;
        }
    }
}
