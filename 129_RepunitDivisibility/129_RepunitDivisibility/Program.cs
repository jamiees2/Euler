using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;

namespace _129_RepunitDivisibility
{
    class Program
    {
        static int A(int n) 
        {
            if (BagMath.Gcd(n, 10) != 1) return 0;
            int k = 1;
            int x = 1;
            while (x != 0)
            {
                x = (x * 10 + 1) % n;
                k++;
            }
            return k;

        }

        static void Main(string[] args)
        {
            const int limit = 1000001;
            int n = limit;
            while (A(n) < limit)
            {
                n += 2;
            }
            Console.WriteLine(n);
            Console.ReadKey();
        }
    }
}
