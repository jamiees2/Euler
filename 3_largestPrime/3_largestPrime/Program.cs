using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_largestPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = 600851475143;
            int i;
            for (i = 2; i < number; i++)
            {
                if ((number % i) == 0)
                {
                    number /= i;
                    i--;
                }
            }
            Console.WriteLine(i);
            Console.ReadKey();
        }
    }
}
