using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _37_TruncatablePrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<long> primes = computePrimes(2000000);
            HashSet<long> firstPrimes = computePrimes(10);
            long[] possibleTruncatable = primes.Where(x => {
                string i = x.ToString();
                return firstPrimes.Contains(Convert.ToInt32(i[0].ToString())) && firstPrimes.Contains(Convert.ToInt32(i[i.Length - 1].ToString())) && i.Length > 1;
            }).ToArray<long>();
            Console.WriteLine(primes.Count + ">" + possibleTruncatable.Length);
            List<long> truncatablePrimes = new List<long>();
            for (int i = possibleTruncatable.Length - 1; i >= 0; i--)
            {
                if (truncatablePrimes.Count >= 11) break;
                string prime = possibleTruncatable[i].ToString();
                if (prime.Length == 1) break;
                bool fail = false;
                for (int j = 0; j < prime.Length; j++)
                {
                    if (!primes.Contains(Convert.ToInt64(prime.Substring(j))) ||
                        !primes.Contains(Convert.ToInt64(prime.Substring(0, prime.Length - j))))
                    {
                        fail = true;
                        break;
                    }
                }
                if (!fail) truncatablePrimes.Add(possibleTruncatable[i]);
            }
            Console.WriteLine(truncatablePrimes.Count);
            foreach (var item in truncatablePrimes)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(truncatablePrimes.Sum());
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
