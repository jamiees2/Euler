using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _94_AlmostEquilateralTriangles
{
    class Program
    {
        static void Main(string[] args)
        {
            //In theory, this should work, not sure why
            long limit = 1000000;
            long result = 0;
            for (long a = 1; a < limit; a++)
            {
                for (long b = Math.Max(1,a- 1); b < a + 1; b++)
                {
                    for (long c = Math.Max(1,a - 1); c < a + 1; c++)
                    {
                        double p = (a + b + c) / 2.0;
                        if (!((a == b && Math.Abs(b - c) == 1) || (b == c && Math.Abs(b - a) == 1) ||
                            (a == c && Math.Abs(a - b) == 1)) ||
                            a + b + c >= limit || p != Math.Floor(p) || p == a || p == b || p == c)
                        {
                            continue;
                        }
                        double d = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                        if (d == Math.Floor(d))
                        {
                            result += (a + b + c);
                            goto End;
                        }
                    }
                }
            End:
                ;

            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
