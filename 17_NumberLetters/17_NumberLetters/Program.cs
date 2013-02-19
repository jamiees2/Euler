using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _17_NumberLetters
{
    class Program
    {
        static string[] intNames = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        static string[] tenNames = { "","ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        static string hundredName = "hundred";
        static string thousandName = "thousand";
        
        static void Main(string[] args)
        {
            List<string> outputNumbers = new List<string>();
            for (int i = 1; i <= 1000; i++)
            {
                int tenRemainder, hundredRemainder, thousandRemainder;
                tenRemainder = hundredRemainder = thousandRemainder = i;
                string thousand = (i < 1000) ? "" : intNames[Math.DivRem(i, 1000, out thousandRemainder)] + thousandName;
                tenRemainder = hundredRemainder = thousandRemainder;
                string hundred = (thousandRemainder == 0 || i < 100) ? "" : intNames[Math.DivRem(thousandRemainder, 100, out hundredRemainder)] + hundredName + ((hundredRemainder > 0) ? "and" : "");
                tenRemainder = hundredRemainder;
                string ten = (hundredRemainder < 20) ? "" : tenNames[Math.DivRem(hundredRemainder,10,out tenRemainder)];
                string one = intNames[tenRemainder];
                outputNumbers.Add(thousand + hundred + ten + one);
                Console.WriteLine(thousand + hundred + ten + one);
            }
            Console.WriteLine(string.Join("",outputNumbers).ToCharArray().Count());
            Console.ReadKey();
        }
    }
}
