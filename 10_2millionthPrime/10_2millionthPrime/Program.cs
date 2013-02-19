using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _10_2millionthPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(computePrimes(2000000).Sum());
            Console.ReadKey();
        }
        public static List<long> computePrimes(int limit)
        {
            BitArray candidates = new BitArray(limit, true);
            List<long> primes = new List<long>();

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
