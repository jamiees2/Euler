using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;
using SharpBag.Strings;

namespace _60_PrimePairSets
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] primes = BagMath.SieveOfEratosthenes(30000).ToArray();
            HashSet<ulong> primesCheck = new HashSet<ulong>(BagMath.SieveOfEratosthenes((ulong)1000000));
            List<int> sums = new List<int>();
            //Console.WriteLine(primes.Length);
            foreach (var prime1 in primes.Where(x => 5 < x && x < 13))
            {
                foreach (var prime2 in primes.Where(x => 
                    primesCheck.Contains(ulong.Parse("" + prime1 + x)) &&
                    primesCheck.Contains(ulong.Parse("" + x + prime1))
                    && x != prime1
                    ))
                {
                    foreach (var prime3 in primes.Where(x => 
                        primesCheck.Contains(ulong.Parse("" + prime1 + x)) && 
                        primesCheck.Contains(ulong.Parse("" + x + prime1)) &&
                        primesCheck.Contains(ulong.Parse("" + prime2 + x)) &&
                        primesCheck.Contains(ulong.Parse("" + x + prime2))
                        && x != prime1 && x != prime2
                        ))
                    {
                        foreach (var prime4 in primes.Where(x =>
                        primesCheck.Contains(ulong.Parse("" + prime1 + x)) &&
                        primesCheck.Contains(ulong.Parse("" + x + prime1)) &&
                        primesCheck.Contains(ulong.Parse("" + prime2 + x)) &&
                        primesCheck.Contains(ulong.Parse("" + x + prime2)) &&
                        primesCheck.Contains(ulong.Parse("" + prime3 + x)) &&
                        primesCheck.Contains(ulong.Parse("" + x + prime3))
                        && x != prime1 && x != prime2 && x != prime3
                        ))
                        {
                            foreach (var prime5 in primes.Where(x =>
                            primesCheck.Contains(ulong.Parse("" + prime1 + x)) &&
                            primesCheck.Contains(ulong.Parse("" + x + prime1)) &&
                            primesCheck.Contains(ulong.Parse("" + prime2 + x)) &&
                            primesCheck.Contains(ulong.Parse("" + x + prime2)) &&
                            primesCheck.Contains(ulong.Parse("" + prime3 + x)) &&
                            primesCheck.Contains(ulong.Parse("" + x + prime3)) &&
                            primesCheck.Contains(ulong.Parse("" + prime4 + x)) &&
                            primesCheck.Contains(ulong.Parse("" + x + prime4))
                            && x != prime1 && x != prime2 && x != prime3 && x != prime4
                            ))
                            {
                                int[] prime = (new int[] { prime1, prime2, prime3, prime4, prime5 });
                                Console.WriteLine(prime.ToStringPretty());
                                sums.Add(prime.Sum());
                                //Console.WriteLine(prime.Sum());
                            }

                        }
                    }
                }
            }
            Console.WriteLine(sums.Min());
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
