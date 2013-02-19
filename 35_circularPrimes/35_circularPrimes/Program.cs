using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _35_circularPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<long> circularPrimes = new HashSet<long>();
            HashSet<long> primes = computePrimes(2000000);
            foreach (long prime in primes)
            {
                if (!circularPrimes.Contains(prime))
                {
                    long[] rotated = rotateInt(prime);
                    bool fail = false;
                    foreach (long rotation in rotated)
                    {
                        if(!primes.Contains(rotation)) fail = true;;
                    }
                    if(!fail)
                        foreach (long rotation in rotated)
                        {
                            circularPrimes.Add(rotation);
                        }
                }
            }
            Console.WriteLine(circularPrimes.Count);
            Console.ReadKey();
        }

        static long[] rotateInt(long number) 
        {
            long[] ret = new long[number.ToString().Length];
            ret[0] = number;
            if(ret.Length == 1) return ret;
            string p = number.ToString();
            for (int i = 1; i < ret.Length; i++)
			{
			    ret[i] = Convert.ToInt64(p.Substring(i,p.Length - i) + p.Substring(0,i));
			}
            return ret;
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
