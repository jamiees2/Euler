using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _50_ConsecutivePrimeSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 1000000;
            HashSet<long> primes = computePrimes(limit);
            List<long> primeList = primes.ToList();
            long highestSum = 0;
            foreach (long prime in primeList)
            {
                if (highestSum + prime > limit) break;
                highestSum += prime;
            }
            int i = 0;
            while (!primes.Contains(highestSum))
            {
                highestSum -= primeList[i];
                i++;
            }
            Console.WriteLine(highestSum);
            Console.ReadKey();
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
