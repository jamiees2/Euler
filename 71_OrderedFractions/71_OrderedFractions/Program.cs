using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;
using SharpBag.Math.ForInt32;
using SharpBag.Strings;

namespace _71_OrderedFractions
{
    class Program
    {
        static void Main(string[] args)
        {
            double closest = 0;
            double topLimit = ((double)3/(double)7);
            double bottomLimit = ((double)2/(double)5);
            double result = 0;
            double denominator = 0;
            for (int d = 1000000; d >= 1; d--)
            {
                for (double n = 1; n < d; n++)
                {
                    if ((n/d) < topLimit && n/d > bottomLimit && BagMath.Gcd((int)d,(int)n) == 1)
                    {
                        if (topLimit- (n / d) <  topLimit - closest)
                        {
                            Console.WriteLine(n + "/"+ d);
                            result = n;
                            denominator = d;
                            closest = (n / d);
                            bottomLimit = closest;
                        }
                    }
                }
            }
            Console.WriteLine(result + "/" + denominator);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
