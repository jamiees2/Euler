using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using Pie.Math.ForInt64;

namespace _66_DiophantineEquations
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            BigInteger pmax = 0;
            //Have not found the solution for when the period is even,
            //decided to see if the max for the numbers where the period is odd worked
            for (int n = 2; n <= 1000; n++)
            {
                int limit = (int)Math.Sqrt(n);
                if (limit * limit == n) continue;

                int period = 0;
                int d = 1;
                int m = 0;
                int a = limit;
                BigInteger p = limit, p2 = 1, pbak = p, q = 1, q2 = 0, qbak = q;
                do
                {
                    m = d*a - m;
                    d = (n - m*m)/d;
                    a = (limit + m)/d;
                    period++;
                    pbak = p;
                    p = a*p + p2;
                    p2 = pbak;
                    qbak = q;
                    q = a*q + q2;
                    q2 = qbak;
                    //if (a == 2 * limit && period % 2 == 1) break;

                //} while (true); 
                } while (a != 2 * limit);
                if (period%2 == 1)
                {
                    if (p > pmax)
                    {
                        result = n;
                        pmax = p;
                    }
                    Console.WriteLine(n + "  " + p + "/" + q);
                }
            }
            Console.WriteLine(result);
            Console.ReadKey();

        }
    }

}
