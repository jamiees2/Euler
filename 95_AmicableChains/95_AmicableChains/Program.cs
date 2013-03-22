using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pie.Math;
using Pie.Strings;

namespace _95_AmicableChains
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxcount = 0;
            var c = new List<int>();
            for (int i = 1; i < 100; i++)
            {
                Console.WriteLine(i);
                var chain = AmicableChain(i);
                if (chain.Count > maxcount)
                {
                    maxcount = chain.Count;
                    c = chain;
                }
            }
            Console.WriteLine(c.ToStringPretty());
            Console.ReadKey();
        }

        static List<int> AmicableChain(int n)
        {
            var list = new List<int>();
            var originalN = n;
            list.Add(n);
            n = n.ProperDivisors().Sum();
            while (originalN != n)
            {
                list.Add(n);
                n = n.ProperDivisors().Sum();
            }
            return list;
        }
    }
}
