using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _21_AmicableNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> amicableNumbers = new HashSet<int>();

            for (int i = 220; i < 10000; i++)
            {
                if (amicableNumbers.Contains(i)) continue;
                int sum = Factorize(i).Sum();
                int sumCheck = Factorize(sum).Sum();
                if (sumCheck == i && sum != i)
                {
                    Console.WriteLine(i + " " + sum);
                    amicableNumbers.Add(i);
                    amicableNumbers.Add(sum);
                }

            }
            Console.WriteLine();
            Console.WriteLine(amicableNumbers.Sum());
            Console.ReadKey();
        }


        static HashSet<int> Factorize(int number)
        {
            HashSet<int> factors = new HashSet<int>();
            int max = (int)Math.Sqrt(number);  //round down
            for (int factor = 1; factor <= max; ++factor)
            { //test from 1 to the square root, or the int below it, inclusive.
                if (number % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != number / factor && factor != 1)
                    { // Don't add the square root twice!  Thanks Jon
                        factors.Add(number / factor);
                    }
                }
            }
            return factors;
        }
    }
}
