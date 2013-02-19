using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _40_ChampernownesConstant
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateIt();
            BruteForceIt();
        }

        static void CalculateIt() 
        {
            StringBuilder builder = new StringBuilder();
            int length = 0;
            int product = 1;
            List<int> powersof10 = new List<int>();
            for (int i = 0; i <= 6; i++)powersof10.Add((int)Math.Pow(10,i));

            for (int i = 1; powersof10.Count != 0; i++)
            {
                length += i.ToString().Length;
                int power = powersof10.First();
                if ((length / power) == 1)
                {
                    Console.WriteLine(i);
                    string str = i.ToString();

                    //Console.WriteLine(power - length + str.Length - 1);
                    product *= Convert.ToInt32(str[power - length + str.Length - 1].ToString());
                    powersof10.Remove(power);
                };
            }
            Console.WriteLine(product);
            Console.ReadKey();
        }

        static void BruteForceIt() 
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i < 1000000; i++)
            {
                builder.Append(i.ToString());
            }
            string constantFraction = builder.ToString();
            long product = 1;
            Console.WriteLine(constantFraction[1000000 - 1]);
            for (int i = 0; i <= 6; i++)
            {
                int num = Convert.ToInt32(constantFraction[((int)Math.Pow(10, i)) - 1].ToString());
                Console.WriteLine(num);
                product *= num;
            }
            Console.WriteLine(product);
            Console.ReadKey();
        }
    }
}
