using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _33_DigitCancellingFractions
{
    class Program
    {
        static void Main(string[] args)
        {
            int numProduct = 1, denProduct = 1 ;
            for (int i = 100 - 1; i >= 0; i--)
            {
                for (int j = 10; j < i; j++)
                {
                    if (IsDigitCancellable(i,j))
                    {
                        
                        int gcd = GCD(i, j);
                        int numDivision = j / gcd, denDivision = i / gcd;
                        for (int k = 1; k < 10; k++)
                        {
                            if (WasCancelled(i, j, denDivision * k, numDivision * k))
                            {
                                Console.WriteLine(j + "/" + i + "=>" + (numDivision) * k + "/" + (denDivision) * k);
                                denProduct *= (denDivision) * k;
                                numProduct *= (numDivision) * k;
                                break;
                            }
                        }
                    }
                }
            }
            
            Console.WriteLine(denProduct / GCD(denProduct,numProduct));
            Console.ReadKey();
        }

        static bool IsDigitCancellable(int n1, int n2) 
        {
            return FindCommonDigit(n1, n2) != null;
        }

        static string FindCommonDigit(int n1, int n2)
        {
            string n1String = n1.ToString();
            string n2String = n2.ToString();
            return (n1String[0] == n2String[1]) ? n1String[0].ToString() : ((n2String[0] == n1String[1]) ? n2String[0].ToString() : null);
            
        }

        static bool WasCancelled(int n1, int n2, int n1Div, int n2Div)
        {
            string n1String = n1.ToString(), n2String = n2.ToString(), n1DivString = n1Div.ToString(), n2DivString = n2Div.ToString();
            if (n1DivString.Length > 1 || n2DivString.Length > 1) return false;
            string digit = FindCommonDigit(n1, n2);
            if (n1String.Replace(digit, "") != n1DivString || n2String.Replace(digit, "") != n2DivString) return false;
            return true;
        }



        public static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int tmp = b;
                b = a % b;
                a = tmp;
            }

            return a;
        }
    }
}
