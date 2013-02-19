using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _20_FactorialSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(100).ToString().ToCharArray().Select(x => Int32.Parse(x.ToString())).Sum());
            Console.ReadKey();
        }
        static BigInteger Factorial(long n) 
        {
            return (n == 2) ? 2 : n * Factorial(n - 1);
        }
    }
}
