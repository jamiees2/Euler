using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pie.Math;

namespace _80_SqrtDigitalExpansion
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = 0;
            for (int i = 1; i <= 100; i++)
            {
                if (Math.Sqrt(i)%1 == 0) continue;
                var t = Sqrt(i, 100);
                result += t.ToString().Where(Char.IsDigit).Take(100).Select(x => int.Parse(x.ToString())).Sum();
                
            }
            Console.WriteLine(result);
            Console.ReadKey();

        }

        static BigDecimal Sqrt(long s, int l)
        {
            var x = new BigDecimal(s,l);
            for (int i = 0; i < 20; x = (((x * x) + s) / (2 * x)), i++) ;
            return x;
        }
    }
}
