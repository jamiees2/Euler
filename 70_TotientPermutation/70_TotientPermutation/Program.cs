using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;
using SharpBag.Strings;
using System.Numerics;

namespace _70_TotientPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            //9999994
            //n/phi(n) =>
            long limit = 10000000L;
            //Loook for primes around the square root of limit => 3000
            int[] primes = BagMath.SieveOfEratosthenes(5000).ToArray();
            long maxResult = 0;
            long resultPhi = 0;
            double minRatio = double.PositiveInfinity;
            for (int i = 0; i < primes.Length; i++)
            {
                for (int j = i + 1; j < primes.Length; j++)
                {
                    //phi(n) can be simplified to (p1 - 1) * (p2 - 1);
                    long n = primes[i] * primes[j];
                    if (n > limit) break;

                    long phi = (primes[i] - 1) * (primes[j] - 1);
                    double ratio = ((double)n) / phi;
                    if (IsPermutation(n,phi) && minRatio > ratio)
                    {
                        maxResult = n;
                        minRatio = ratio;
                        resultPhi = phi;
                    }
                }
            }
            Console.WriteLine(maxResult + " " + resultPhi);
            Console.ReadKey();
        }

        static bool IsPermutation(long n, long n1)
        {
            var nDigits = n.Digits();
            var n1Digits = n1.Digits();
            foreach (var digit in n.Digits())
            {
                if (n1Digits.Count(x => x == digit) != nDigits.Count(x => x == digit)) return false;
            }
            return true;
        }
    }
}
