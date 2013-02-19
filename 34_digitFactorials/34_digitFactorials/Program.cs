using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _34_digitFactorials
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cache = new int[10];
            for (int i = 0; i < 10; i++) cache[i] = fact(i);
            int sum = 0;
            //1854751 is the upper bound of the possible factorions
            //see http://en.wikipedia.org/wiki/Factorion
            for (int i = 3; i < 1854751; i++)
            {
                if (i.ToString().Select(x => cache[Convert.ToInt32(x.ToString())]).Sum() == i) sum += i;
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }

        static int fact(int n) 
        {
            return (n < 1) ? 1 : n * fact(n - 1);
        }
    }
}
