using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pie.Math;

namespace _73_CountingFractionsRange
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = 0;
            for (double i = 1; i <= 12000; i++)
            {
                for (double j = 1; j < i; j++)
                {
                    if (BagMath.Gcd((int)i, (int)j) == 1 && j/i > 1/3.0 && j/i < 1/2.0)
                    {
                        result++;
                    }
                }
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
