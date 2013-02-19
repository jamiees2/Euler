using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _15_LatticePaths
{
    class Program
    {
        static void Main(string[] args)
        {
            /// n = 20
            ///Every way down takes 2n turns
            ///Can only turn right or down
            ///Must turn right n times, and down n times
            ///So we choose right 20 times into 40 positions, the rest gets filled with down
            ///C(2n,n) = ((2n)!)/(n!)^2
            
            Console.WriteLine(fact(40) / BigInteger.Pow(fact(20),2));
            Console.WriteLine(LatticePaths(20,20));
            Console.ReadKey();
        }

        //Generalizes problem to m * n grids
        static BigInteger LatticePaths(int m, int n) 
        {
            return fact(m + n) / (fact(m) * fact(n));
        }


        static BigInteger fact(BigInteger n) 
        {
            return (n == 0) ? 1 : n * fact(n - 1);
        }
    }
}
