using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pie.Math;
using Pie.Strings;

namespace _58_SpiralPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            double ratio = Double.PositiveInfinity;
            var i = 1;
            //var primes = new HashSet<int>(BagMath.SieveOfEratosthenes(450000000));
            //var max = primes.Max();
            var prime = 0;
            while (ratio > 0.1)
            {
                i += 2;
                var count = (i * 2) - 1;
                var pow = i*i;
                var j = i - 1;
                if ((pow - j).IsPrime()) prime++;
                if ((pow - j * 2).IsPrime()) prime++;
                if ((pow - j * 3).IsPrime()) prime++;
                ratio = prime / (double) count;
            }
            Console.WriteLine(i);
            Console.ReadKey();
        }
    }
}
