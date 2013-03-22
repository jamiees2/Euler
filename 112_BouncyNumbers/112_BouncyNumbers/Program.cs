using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pie;
using Pie.Math;
using Pie.Strings;

namespace _112_BouncyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //int limit = 538;
            int count = 0;
            int i = 0;
            do
            {
                if (IsBouncy(i)) count++;
                i++;
            }
            while ((count/(double) (i - 1)) != 0.99) ;
            Console.WriteLine(i - 1);
            Console.ReadKey();
        }

        static bool IsBouncy(int n)
        {
            var s = n.ToString();
            var ordered = n.Digits().OrderBy(x => x).ToStringPretty(delimiter: "");
            return !(s == ordered|| s == ordered.Reverse());
        }
    }
}
