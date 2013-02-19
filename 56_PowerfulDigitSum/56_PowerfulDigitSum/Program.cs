using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _56_PowerfulDigitSum
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger maxSum = 0;
            for (int a = 1; a <= 100; a++)
            {
                for (int b = 1; b <= 100; b++)
                {
                    maxSum = BigInteger.Max(maxSum,digitSum(BigInteger.Pow(a,b)));
                }
            }
            Console.WriteLine(maxSum);
            Console.ReadKey();
        }

        static BigInteger digitSum(BigInteger n) 
        {
            return n.ToString().Select(x => Int32.Parse(x.ToString())).Sum();
        }
    }
}
