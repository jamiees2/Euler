using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;
using SharpBag.Strings;

namespace _88_Product_sumNumbers
{
    static class IntExtensions 
    {
        public static int Product(this IEnumerable<int> s)
        { 
            return s.Aggregate(1,(result,next) => result *= next);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> numbers = new HashSet<int>();
            for (int k = 2; k <= 12; k++)
            {
                for (int i = k; i <= k * k; i++)
                {
                    List<int> factors = i.PrimeFactors().ToList();
                    while(factors.Count < k)
                    {
                        factors.Add(1);
                    }
                    factors.Sort();
                    int j = factors.Count - 1;
                    while (factors[j] != 1 && factors.Sum() != factors.Product())
                    {
                        factors[j - 1] = factors[j] * factors[j - 1];
                        factors.Remove(factors[j]);
                        factors.Insert(0, 1);
                        j--;
                    }

                    if (factors.Sum() == factors.Product())
                    {
                        Console.WriteLine(k + " " + i + "    " + factors.ToStringPretty());
                        if (! numbers.Contains(i))
                        {
                            numbers.Add(i);
                        }
                        break;
                    }
                }
            }
            Console.WriteLine(numbers.Sum());
            Console.ReadKey();
        }
    }
}
