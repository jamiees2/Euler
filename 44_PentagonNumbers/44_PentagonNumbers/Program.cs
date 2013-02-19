using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _44_PentagonNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<BigInteger> pentagonals = CalculateNPentagonals(10000);
            for (int i = 1; i < pentagonals.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    BigInteger iPent = pentagonals.ElementAt(i), jPent = pentagonals.ElementAt(j);
                    if (pentagonals.Contains(iPent + jPent) && pentagonals.Contains(iPent - jPent)) 
                    {
                        Console.WriteLine(iPent - jPent );
                        break;
                    }
                }
            }
            Console.ReadKey();
        }

        static HashSet<BigInteger> CalculateNPentagonals(int limit) 
        {
            HashSet<BigInteger> ret = new HashSet<BigInteger>();
            for (int i = 1; i <= limit; i++)
            {
                ret.Add(i * ((3 * i) - 1) / 2);
            }
            return ret;
        }
    }
}
