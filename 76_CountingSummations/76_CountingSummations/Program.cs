using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _76_CountingSummations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(p(1,100) - 1);
            Console.ReadKey();
        }

        static long p(int k, int n)
        {
            if (k > n)
            {
                return 0;
            }
            if (k == n)
            {
                return 1;
            }
            return p(k + 1,n) + p(k, n - k);
        }
    }
}
