using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _38_PandigitalMultiples
{
    class Program
    {
        static void Main(string[] args)
        {/*
            string number = "";
            int i = 1;
            while (number.Length < 9)
            {
                number += (192 * i).ToString();
                i++;
            }
            Console.WriteLine(number);*/
            
            int maxN = 0;
            long maxPandigital = 0;
            for (int n = 2; n < 100000; n++)
            {
                string number = "";
                int i = 1;
                while (number.Length < 9)
                {
                    number += (n * i).ToString();
                    i++;
                }
                if (IsPandigital(number) && Int64.Parse(number) > maxPandigital)
                {
                    maxN = n;
                    maxPandigital = Int64.Parse(number);
                }
            }
            Console.WriteLine(maxN + " " + maxPandigital);
            Console.ReadKey();
        }

        static bool IsPandigital(string nString)
        {
            for (int i = 1; i <= nString.Length; i++)
            {
                if (nString.Count(x => x.ToString() == i.ToString()) != 1) return false;
            }
            return true;
        }
    }
}
