using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _85_CountingRectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            int jMax = Int32.MaxValue;
            int iMax = Int32.MaxValue;
            int closest = 0;
            for (int i = 10; i < 100000; i++)
            {
                int j = 0;
                int close = 0;
                while ((close = NumberOfRectangles(i,j)) < 2000000)
                {
                    j++;
                }
                if (Math.Abs(2000000 - close) > Math.Abs(2000000 - NumberOfRectangles(i,j - 1)))
                {
                    j--;
                    close = NumberOfRectangles(i, j);
                }
                if (Math.Abs(2000000 - closest) > Math.Abs(2000000 - close) )
                {
                    closest = close;
                    jMax = j;
                    iMax = i;
                }
            }
            Console.WriteLine(iMax + " " + jMax + "  " + (iMax * jMax) + "  " + NumberOfRectangles(iMax,jMax));
            Console.ReadKey();
        }

        static int NumberOfRectangles(int n, int m)
        {
            return (m * (m + 1) * n * (n + 1)) / 4;
        }
    }
}
