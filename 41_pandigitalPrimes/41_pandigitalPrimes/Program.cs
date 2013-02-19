using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _41_pandigitalPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<long> primes = computePrimes(100000000);
            Console.WriteLine(primes.Where(x => isPandigital(x.ToString())).Max());
            Console.ReadKey();
        }

        static bool isPandigital(string nString)
        {
            for (int i = 1; i <= nString.Length; i++)
            {
                if (nString.Count(x => x.ToString() == i.ToString()) != 1) return false;
            }
            return true;
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
