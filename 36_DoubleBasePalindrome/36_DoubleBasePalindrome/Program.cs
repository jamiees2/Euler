using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _36_DoubleBasePalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 1000000 - 1; i >= 0; i-=2)
            {
                if (isPalindrome(i.ToString()))
                {
                    if (isPalindrome(Convert.ToString(i,2)))
	                {
                        sum += i;
	                }
                }
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }

        static bool isPalindrome(string nString)
        {
            int n = nString.Length;
            for (int i = 0; i < n / 2; i++)
            {
                if (nString[i] != nString[n - (i + 1)])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
