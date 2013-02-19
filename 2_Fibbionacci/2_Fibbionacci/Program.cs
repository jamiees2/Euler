using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2_Fibbionacci
{
    class Program
    {
        static void Main(string[] args)
        {
            
            long sum = 0;
            int c = 3;
            long m = 0;
            while (true)
            {
                m = fib(c);
                if (m > 4 * Math.Pow(10, 6)) break;
                sum += m;
                c += 3;
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }

        static int fib(int n) 
        {
            return (n == 1) ? 1 : ((n == 0) ? 0 : fib(n - 1) + fib(n - 2));
        }
    }
}
