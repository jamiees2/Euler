using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;

namespace _69_TotientMaximum
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 10;
            int[] primes = BagMath.SieveOfEratosthenes(limit*2).ToArray<int>();
            int result = 1;
            int i = 0;
            while ((result * primes[i]) < limit)
            {
                result *= primes[i];
                i++;
               
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }

        static int Totient(int n)
        {
            int[] primes = BagMath.SieveOfEratosthenes(n - 1).ToArray();    //this can be precalculated beforehand
            int numPrimes = primes.Length;

            int totient = n;
            int currentNum = n, temp, p, prevP = 0;
            for (int i = 0; i < numPrimes; i++)
            {
                p = (int)primes[i];
                if (p > currentNum) break;
                temp = currentNum / p;
                if (temp * p == currentNum)
                {
                    currentNum = temp;
                    i--;
                    if (prevP != p) { prevP = p; totient -= (totient / p); }
                }
            }
            return totient;
        }
    }
}
