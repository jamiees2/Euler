using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12_500factorsTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<long, int> numbers = new Dictionary<long, int>();
            for (int i = 10000; i < 15000; i++)
            {
                long triangle = GetNthTriangle(i);
                numbers.Add(triangle,Factorize(triangle).Count());
            }
            foreach (var item in numbers.Where(x => x.Value > 500))
            {
                Console.WriteLine(item.Key);
            }
            Console.ReadKey();
        }

        static List<long> Factorize(long number)
        {
            List<long> factors = new List<long>();
            int max = (int)Math.Sqrt(number);  //round down
            for (int factor = 1; factor <= max; ++factor)
            { //test from 1 to the square root, or the int below it, inclusive.
                if (number % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != number / factor)
                    { // Don't add the square root twice!  Thanks Jon
                        factors.Add(number / factor);
                    }
                }
            }
            return factors;
        }

        static long GetNthTriangle(int n) 
        {
            return Enumerable.Range(1, n).Sum();
        }

    }
}
