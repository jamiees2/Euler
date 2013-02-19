using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _16_PowerSum
{
    class Program
    {
        static void Main(string[] args)
        {
            //Use BigInteger for added l33tness
            BigInteger tothe100th = BigInteger.Pow(2,1000);
            Console.WriteLine(tothe100th.ToString().ToCharArray().Select(x => Int32.Parse(x.ToString())).Sum());
            Console.ReadKey();
        }
    }
}
