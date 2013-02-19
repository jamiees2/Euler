using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _23_NonAbundantSums
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> abundantNumbers = FindAbundantNumbersBelowN(28123);
            HashSet<int> abundantSums = new HashSet<int>();
            List<int> nonAbundantSums = new List<int>();
            foreach (int i in abundantNumbers)
            {
                foreach (int j in abundantNumbers)
                {
                    abundantSums.Add( i + j );
                }
            }
            for (int i = 1; i <= 28123; i++)
            {
                if (!abundantSums.Contains(i)) nonAbundantSums.Add(i);
            }
            Console.WriteLine(nonAbundantSums.Sum());
            Console.ReadKey();
        }

        static List<long> FindAbundantNumbersBelowN(int N) 
        {
            List<long> abundantNumbers = new List<long>();
            if (N < 12) return abundantNumbers;
            for (int i = 12; i < N; i++)
            {
                if (Factorize(i).Sum() > i) abundantNumbers.Add(i);
            }
            return abundantNumbers;
        }

        static bool isNotSumOfAbundant(int check, List<long> abundantNumbers) 
        {
            IEnumerable<long> abundantNumbersBelowCheck = abundantNumbers.Where(x => x < check);
            if (abundantNumbersBelowCheck.Count() == 0) return true;
            foreach (var abundantNumber in abundantNumbersBelowCheck)
            {
                if (abundantNumbers.Contains(check - abundantNumber))
                {
                    return true;
                }
            }
            return false;
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
