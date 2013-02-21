using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _39_IntegerRightAngle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] solutions = new int[999];
            int pMax = 0;
            int solutionCountMax = 0;
            for (int p = 1; p < 1000; p++)
            {
                int tempSolution = 0;
                for (int a = 0; a < p; a++)
                {
                    for (int b = p - a; b >= 0; b--)
                    {
                        double c;
                        if ( (c = Math.Sqrt(a * a + b * b)) % 1 == 0 && (a + b + c == p))
                            tempSolution++;
                    }
                }
                if (tempSolution > solutionCountMax) 
                {
                    pMax = p;
                    solutionCountMax = tempSolution;
                }
            }
            Console.WriteLine(pMax);
            Console.ReadKey();
        }
    }
}
