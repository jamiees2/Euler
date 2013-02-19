using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _25_1000digitFibbonacciNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 10000; i++)
            {
                BigInteger j = fib(i);
                if (j.ToString().Length == 1000)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
            Console.ReadKey();
        }

        static Dictionary<int, BigInteger> cache = new Dictionary<int, BigInteger>();
        static BigInteger fib(int n) 
        {
            if (cache.Count == 0) 
            {
                cache.Add(1, 1);
                cache.Add(2, 1);
            }
            if (cache.ContainsKey(n)) return cache[n];
            else
            {
                BigInteger calc = fib(n - 1) + fib(n - 2);
                cache.Add(n, calc);
                return calc;
            }
            //check cache for number
            //if exists, return it
            //else, calculate with fib(n) = fib(n - 1) + fib(n - 2)
        }
    }
}
