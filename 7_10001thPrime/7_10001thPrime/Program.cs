using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _7_10001thPrime
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(computePrimes(200000)[10001]);
            Console.ReadKey();
        }

        static bool IsPrime(int num) 
        {
            if ((num % 2) == 0) return false;
            for (int i = 3; i <= Math.Sqrt(num); i+=2)
            {
                if ((num % i) == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static List<int> computePrimes(int limit)
        {
            BitArray candidates = new BitArray(limit, true);
            List<int> primes = new List<int>();

            for (int i = 2; i < limit; i++)
            {
                if (candidates[i])
                {
                    for (int j = i * 2; j < limit; j += i)
                    { candidates[j] = false; }
                }
            }
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
