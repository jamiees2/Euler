using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4_Palindrome3digit
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> possible = new List<int>();
            for (int i = 100; i < 1000; i++)
            {
                for (int j = 100; j < 1000; j++)
                {
                    if (isPalindrome(i * j))
                    {
                        possible.Add(i * j);
                    }
                }
            }
            Console.WriteLine(possible.Max());
            Console.ReadKey();
        }
        static bool isPalindrome(int number) 
        {
            char[] contains = number.ToString().ToCharArray();
            int n = contains.Count();
            if ((n % 2) == 1) return false;
            for (int i = 0; i < n / 2; i++)
            {
                if (contains[i] != contains[n - (i + 1)])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
