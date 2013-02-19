using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _32_PandigitalProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> firstProduct = Enumerable.Range(1, 99).Where(x => !RepeatsCharacters(x));
            IEnumerable<int> secondProduct = Enumerable.Range(100, 9900).Where(x => !RepeatsCharacters(x));
            IEnumerable<int> products = (from a in firstProduct
                                        from b in secondProduct
                                        where isPandigital(a.ToString() + b.ToString() + (a * b).ToString())
                                        select a * b).Distinct();
            Console.WriteLine(products.Sum());
            Console.ReadKey();
        }

        static bool isPandigital(string nString) 
        {
            for (int i = 1; i < 10; i++)
            {
                if (nString.Count(x => x.ToString() == i.ToString()) != 1) return false;
            }
            if (nString.Length > 9) return false;
            return true;
        }

        static bool RepeatsCharacters(int n) 
        {
            string nString = n.ToString();
            foreach (char i in nString)
            {
                if (nString.Count(x => x == i) > 1) return true;
            }
            return false;
        }
    }
}
