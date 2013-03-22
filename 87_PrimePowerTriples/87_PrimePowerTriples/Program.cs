using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pie.Math;

namespace _87_PrimePowerTriples
{
    class Program
    {
        static void Main(string[] args)
        {
            var primes = BagMath.SieveOfEratosthenes(1000000).ToList();
            var primes4th = primes.Select(x => Math.Pow(x, 4)).ToList();
            var primes3rd = primes.Select(x => Math.Pow(x, 3)).ToList();
            var primes2nd = primes.Select(x => Math.Pow(x, 2)).ToList();
            for (int i = 1; i < 50; i++)
            {
                if
            }
        }
    }
}
