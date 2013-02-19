using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _49_PrimePermutations
{
    class Program
    {
        static void Main(string[] args)
        {
            var primes = computePrimes(10000);
            ///first, select all primes that are 4 characters
            
            List<long> candidates = primes.Where(x => x > 1000).ToList();
            List<int> numbers = new List<int>();
            foreach (var prime in candidates)
            {
                long secondPrime = 0;
                long thirdPrime = 0;
                foreach (var check in primes.Where(x => x > prime && IsPermutationOf(prime.ToString(),x.ToString())))
                {
                    thirdPrime = check + (check - prime);
                    if (primes.Contains(check + (check - prime)) && IsPermutationOf(prime.ToString(), thirdPrime.ToString()))
                    {
                        secondPrime = check;
                        break;
                    }
                }
                if (secondPrime != 0)
                {
                    Console.WriteLine(prime + " " + secondPrime + " " + thirdPrime);
                }
            }

            Console.ReadKey();
        }

        static bool IsPermutationOf(string first, string second)
        {
            if (second.Length > first.Length || second.Length < first.Length) return false;
            foreach (var c in first)
            {
                if (second.Count(x => x == c) != first.Count(x => x == c))
                {
                    return false;
                }
            }
            return true;
        }

        static IEnumerable<string> GetAllStrings(params char[] inputCharacterSet)
        {
            return from n in inputCharacterSet
                   from m in inputCharacterSet
                   from k in inputCharacterSet
                   from l in inputCharacterSet
                   where n!=m && m!=k && n!=k && n!=l && m!=l && k!=l
                   select new string(new[] { n, m, k, l });
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
