using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _31_CoinSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = 200;
            int[] coinSizes = { 1, 2, 5, 10, 20, 50, 100, 200 };
            int[] ways = new int[target + 1];
            ways[0] = 1;

            for (int i = 0; i < coinSizes.Length; i++)
            {
                for (int j = coinSizes[i]; j <= target; j++)
                {
                    ways[j] += ways[j - coinSizes[i]];
                }
            }
            Console.WriteLine(ways[ways.Length - 1]);
            Console.ReadKey();
        }
    }
}
