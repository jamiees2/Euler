using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math.ForBigInteger;
using SharpBag.Math;
using System.Numerics;

namespace _57_SquareRootConvergents
{
    class Program
    {
        static void Main(string[] args)
        {
            int c = 0;
            
            for (int a = 1; a < 1000; a++)
            {
                int count = a;
                Fraction i = new Fraction(1,2);
                while (count > 1)
                {
                    i = 1/(2 + i);
                    count--;
                }
                i += 1;
                //Console.WriteLine(i);
                if (i.Numerator.ToString().Length > i.Denominator.ToString().Length)
                {
                    c++;

                    Console.WriteLine(c + "  " + a);
                }
            }
            //Implement newton's method
            /*
            Fraction i = new Fraction(1,2);
            Fraction multiplier = new Fraction(1,2);
            int count = 0;
            while (count++ < 1000)
            {
                i = i * multiplier + i.Reciprocal * 2;
                if (i.Numerator.ToString().Length > i.Denominator.ToString().Length)
                {
                    c++;
                    Console.WriteLine(c + "  " + count);
                }
            }*/

            Console.WriteLine(c);
            Console.ReadKey();
        }
    }
}
