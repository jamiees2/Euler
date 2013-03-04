using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _64_OddPeriods
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperbound = 10000;
            int result = 0;

            for (int n = 2; n <= upperbound; n++)
            {
                int limit = (int)Math.Sqrt(n);
                if (limit * limit == n) continue;

                int period = 0;
                int d = 1;
                int m = 0;
                int a = limit;

                do
                {
                    m = d * a - m;
                    d = (n - m * m) / d;
                    a = (limit + m) / d;
                    period++;
                } while (a != 2 * limit);

                if (period % 2 == 1) result++;
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
