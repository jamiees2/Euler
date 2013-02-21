using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;

namespace _43_SubStringDivisibility
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  d2d3d4 =406 is divisible by 2
                d3d4d5 =063 is divisible by 3
                d4d5d6 =635 is divisible by 5
                d5d6d7 =357 is divisible by 7
                d6d7d8 =572 is divisible by 11
                d7d8d9 =728 is divisible by 13
                d8d9d10 =289 is divisible by 17
             */
            ///d4 is any one of {0,2,4,6,8}
            ///d6 is 5
            ///d6d7d8 must be divisible by 11, if d6 is 0, then they will not be pandigital {011,022....}
            ///d3 + d4 + d5 must be divisible by 3
            ///
            /*
            List<BigInteger> pandigitals = new List<BigInteger>();
            for (int a = 17; a < 1000; a += 17)
            {
                //if (a < 100) continue;
                if (!IsDistinct(a)) continue;
                for (int b = 13; b < 1000; b+=13)
                {
                    //if (b < 100) continue;
                    if (!IsDistinct(b)) continue;
                    if (!StartsWith(a, b.ToString().Substring(1))) continue;
                    for (int c = 11; c < 1000; c+=11)
                    {
                        //if (c < 100) continue;
                        if (!IsDistinct(c)) continue;
                        if (!StartsWith(b, c.ToString().Substring(1))) continue;
                        for (int d = 7; d < 1000; d += 7)
                        {
                            //if (d < 100) continue;
                            if (!IsDistinct(d)) continue;
                            if (!StartsWith(c, d.ToString().Substring(1))) continue;
                            for (int e = 5; e < 1000; e += 5)
                            {
                                //if (e < 100) continue;
                                if (!IsDistinct(e)) continue;
                                if (!StartsWith(d, e.ToString().Substring(1))) continue;
                                for (int f = 3; f < 1000; f += 3)
                                {
                                    //if (f < 100) continue;
                                    if (!IsDistinct(f)) continue;
                                    if (!StartsWith(e, f.ToString().Substring(1))) continue;
                                    for (int g = 2; g < 1000; g += 2)
                                    {
                                        //if (g < 100) continue;
                                        if (!IsDistinct(g)) continue;
                                        if (!StartsWith(f, g.ToString().Substring(1))) continue;

                                        string testString = "";
                                        int firstCount = g.Digits().Count();
                                        testString += g.Digits().Aggregate("", (result, next) => result += next);
                                        testString += f.Digits().Last();
                                        testString += e.Digits().Last();
                                        testString += d.Digits().Last();
                                        testString += c.Digits().Last();
                                        testString += b.Digits().Last();
                                        testString += a.Digits().Last();
                                        //m + g + f + e + d + c + b + a{2}
                                        while (testString.Length != 8)
                                        {
                                            testString = "0" + testString;
                                        }

                                        if (IsDistinct(Int64.Parse(testString)))
                                        {
                                            var missingDigits = Enumerable.Range(0, 9).Except(testString.Select((x) => Int32.Parse(x.ToString())));
                                            int missingDigit = missingDigits.First();
                                            testString = missingDigit + testString;
                                            Console.WriteLine(testString);
                                            pandigitals.Add(BigInteger.Parse(testString));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(pandigitals.Aggregate((result,next) => result += next));*/

            //int a = 789, b = 678, c = 567, d = 456, e = 345, f = 234, g = 12;
            //Cant figure out previous solution, current solution copied from mathblog.dk
            long result = 0;
            int[] divisors = { 1, 2, 3, 5, 7, 11, 13, 17 };

            int count = 1;
            int numPerm = 3265920;

            while (count < numPerm)
            {
                int N = perm.Length;
                int i = N - 1;
                while (perm[i - 1] >= perm[i])
                {
                    i = i - 1;
                }

                int j = N;
                while (perm[j - 1] <= perm[i - 1])
                {
                    j = j - 1;
                }

                // swap values at position i-1 and j-1
                swap(i - 1, j - 1);

                i++;
                j = N;
                while (i < j)
                {
                    swap(i - 1, j - 1);
                    i++;
                    j--;
                }
                bool divisible = true;
                for (int k = 1; k < divisors.Length; k++)
                {
                    int num = 100 * perm[k] + 10 * perm[k + 1] + perm[k + 2];
                    if (num % divisors[k] != 0)
                    {
                        divisible = false;
                        break;
                    }
                }
                if (divisible)
                {
                    long num = 0;
                    for (int k = 0; k < perm.Length; k++)
                    {
                        num = 10 * num + perm[k];
                    }
                    result += num;
                }
                count++;
            }
            Console.WriteLine(result);
            Console.ReadKey();

        }
        static int[] perm = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static void swap(int i, int j)
        {
            int k = perm[i];
            perm[i] = perm[j];
            perm[j] = k;
        }

        static bool StartsWith(int n, string b)
        {
            return n.ToString().StartsWith(b);
        }

        static bool IsDistinct(long n)
        {
            var digits = n.Digits();
            foreach (var digit in digits)
            {
                if (digits.Count(x => x == digit) != 1) return false;
            }
            return true;
        }

        static bool IsPandigital(string nString, int start)
        {
            for (int i = start; i <= nString.Length; i++)
            {
                if (nString.Count(x => x.ToString() == i.ToString()) != 1) return false;
            }
            return true;
        }
    }
}
