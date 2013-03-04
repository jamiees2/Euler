using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _72_CountingFractions
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 1000000;
            int[] phi = Enumerable.Range(0, limit + 1).ToArray();
            long result = 0;
            for (int i = 2; i <= limit; i++)
            {
                if (phi[i] == i)
                {
                    for (int j = i; j <= limit; j += i)
                    {
                        phi[j] = phi[j] / i * (i - 1);
                    }
                }
                result += phi[i];
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}

