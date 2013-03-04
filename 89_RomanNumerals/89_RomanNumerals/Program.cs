using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _89_RomanNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            string[] numerals = File.ReadAllLines("roman.txt");
            foreach (string numeral in numerals)
            {
                result += numeral.Length - ToRoman(FromRoman(numeral)).Length;
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int FromRoman(string number)
        {
            char[] digits = number.ToCharArray();
            int result = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] == 'M') result += 1000;
                else if ((i + 1) < digits.Length && digits[i] == 'C' && digits[i + 1] == 'M')
                {
                    i++;
                    result += 900;
                }
                else if (digits[i] == 'D') result += 500;
                else if ((i + 1) < digits.Length && digits[i] == 'C' && digits[i + 1] == 'D')
                {
                    i++;
                    result += 400;
                }
                else if (digits[i] == 'C') result += 100;
                else if ((i + 1) < digits.Length && digits[i] == 'X' && digits[i + 1] == 'C')
                {
                    i++;
                    result += 90;
                }
                else if (digits[i] == 'L') result += 50;
                else if ((i + 1) < digits.Length && digits[i] == 'X' && digits[i + 1] == 'L')
                {
                    i++;
                    result += 40;
                }
                else if (digits[i] == 'X') result += 10;
                else if ((i + 1) < digits.Length && digits[i] == 'I' && digits[i + 1] == 'X')
                {
                    i++;
                    result += 9;
                }
                else if (digits[i] == 'V') result += 5;
                else if ((i + 1) < digits.Length && digits[i] == 'I' && digits[i + 1] == 'V')
                {
                    i++;
                    result += 4;
                }
                else if (digits[i] == 'I') result += 1;
            }
            return result;
        }

        public static string ToRoman(int number)
        {
            //if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }
    }
}
