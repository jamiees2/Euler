using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;
using SharpBag;
using SharpBag.Strings;

namespace _51_PrimeDigitReplacements
{
    class Program
    {
        static void Main(string[] args)
        {
            var primes = BagMath.SieveOfEratosthenes(10000000).ToList();
            var primesCheck = new HashSet<int>(primes);
            
            foreach (var prime in primes)
            {
                Console.WriteLine(prime);
                var digits = prime.Digits().ToList();
                if (digits.Count < 2) continue;
                var primestr = prime.ToString();
                var maxCount = 0;
                foreach (var c in digits.Distinct())
                {
                    if (digits.Count(x => x == c) <= 1) continue;
                    var count = 0;
                    var start = 0;
                    if (primestr.StartsWith(c.ToString())) start = 1;
                    for (int i = start; i < 10; i++)
                    {
                        var candidate = primestr.Replace(c.ToString(), i.ToString()).As<int>();
                        if (primesCheck.Contains(candidate))
                        {
                            count++;
                            Console.Write(candidate + " ");
                        }
                    }
                    maxCount = Math.Max(maxCount, count);
                }
                if (maxCount == 8)
                {
                    Console.WriteLine(prime);
                    goto Exit;
                }
                Console.WriteLine();
            }
            Exit:
                Console.ReadKey();
        }
    }
}
