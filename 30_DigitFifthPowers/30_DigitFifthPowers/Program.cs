using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _30_DigitFifthPowers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> vals = new List<int>();
            for (BigInteger i = 2; i < 355000; i++)
            {
                if ((BigInteger)i.ToString().Select(x => Int32.Parse(x.ToString())).Select(x => BigInteger.Pow(x,5)).Aggregate((result,next) => result += next) == i)
                {
                    vals.Add((int)i);
                }
            }
            foreach (var item in vals)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(vals.Sum());
            Console.ReadKey();
        }
    }
}
