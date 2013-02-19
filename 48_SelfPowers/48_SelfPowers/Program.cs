using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _48_SelfPowers
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger result = 0;
            for (int i = 1; i < 1000; i++)
            {
                
                string power = BigInteger.Pow(i, i).ToString();
                result += BigInteger.Parse(power.Substring(Math.Max(0,power.Length - 10)));
                string resultString = result.ToString();
                result = BigInteger.Parse(resultString.Substring(Math.Max(0,resultString.Length - 10)));
                //result += BigInteger.Pow(i,i);
            }
            //string resultString = result.ToString();
            //Console.WriteLine(resultString.Substring(resultString.Length - 10));
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
