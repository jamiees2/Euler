using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _28_NumberSpiralDiagonals
{
    class Program
    {
        static void Main(string[] args)
        {
            //the corners of each spiral with a size n^2 = 
            long sum = 0;
            long currentPower = 0;
            for (int i = 1001; i >= 0; i-=2)
            {
                currentPower = (long)Math.Pow(i, 2);
                sum += currentPower;
                if (currentPower == 1) break;
                for (int j = 1; j < 4; j++)
                {
                    sum += currentPower - (i - 1) * j;
                }
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
