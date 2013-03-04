using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using SharpBag.Math;

namespace _62_CubicPermutations
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
        }

        static bool IsPermutation(BigInteger n1, BigInteger n2)
        {
            return n1.Digits().Except(n2.Digits()).Count() == 0;
        }

    }
}
