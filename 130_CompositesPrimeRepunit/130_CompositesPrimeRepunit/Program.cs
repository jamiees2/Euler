using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;

namespace _130_CompositesPrimeRepunit
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
            const int limit = 25;
            int sum = 0;
            int k = 0;
            int n = 5;
            while (k < limit)
            {
                if (!BagMath.IsPrime(n) && BagMath.Gcd(n, 10) == 1 && (n - 1) % A(n) == 0)
                {
                    //Console.WriteLine(n);
                    sum += n;
                    k++;
                }
                n+=2;
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
