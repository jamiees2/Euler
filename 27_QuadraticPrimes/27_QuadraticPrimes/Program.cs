using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;

namespace _27_QuadraticPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            //n^2 + a*n + b 
            int a = 1, b = 0, length = 0;
            Console.WriteLine("here");
            HashSet<int> primes = new HashSet<int>(BagMath.SieveOfEratosthenes(100000));
            //B must be prime
            int[] bPossible = BagMath.SieveOfEratosthenes(1000).ToArray<int>();

            Console.WriteLine("Here");
            //If n is one, then the formula won't generate a prime unless a is odd
            
            for (int c = -999; c < 1001; c += 2)
            {
                for (int i = 1; i < bPossible.Length; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        
                        int n = 0;

                        int sign = (j == 0) ? 1 : -1;
                        int aodd = (i % 2 == 0) ? -1 : 0; // Making a even if b is even
                        while (primes.Contains(n * n + (c + aodd) * n + sign * bPossible[i]))
                        {
                            n++;
                        }
                        if (n > length)
                        {
                            length = n;
                            b = bPossible[i];
                            a = c;
                        }
                    }
                }
            }
            Console.WriteLine(a + "*" + b + "=" + (a * b));
            Console.ReadKey();
        }
    }
}
