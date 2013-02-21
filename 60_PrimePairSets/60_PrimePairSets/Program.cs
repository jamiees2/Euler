using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;

namespace _60_PrimePairSets
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] primes = BagMath.SieveOfEratosthenes(30000).ToArray();
            HashSet<int> primesCheck = new HashSet<int>(BagMath.SieveOfEratosthenes(1000000));
            Console.WriteLine(primes.Length);
            for (int i = 1; i < primes.Count(x => x < 10); i++)
            {
                for (int j = i + 1; j < primes.Count(x => x < 100); j++)
                {
                    for (int k = j + 1; k < primes.Count(x => x < 1000); k++)
                    {
                        for (int l = k + 1; l < primes.Count(x => x < 10000); l++)
                        {
                                
                                if (pairs(primes[i], primes[j], primes[k], primes[l]/*, primes[m]*/).All(primesCheck.Contains))
                                {

                                    Console.WriteLine(primes[i] + " " + primes[j] + " " + primes[k] + " " + primes[l] + " "/* + primes[m]*/);
                                    break;
                                }
                            
                            
                        }
                    }
                }
            }
            Console.ReadKey();
        }

        static IEnumerable<int> pairs(params object[] p) 
        {
            IEnumerable<int> set = p.Cast<int>();
            foreach (var num in set)
            {
                foreach (var num2 in set)
                {
                    if (num == num2) continue;
                    yield return Int32.Parse("" + num + num2);
                }
            }
        }
    }
}
