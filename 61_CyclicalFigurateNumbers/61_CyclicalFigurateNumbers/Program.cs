using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Math;
using SharpBag.Strings;

namespace _61_CyclicalFigurateNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> possibles = new List<List<int>>();
            for (int a = 1000; a < 10000; a++)
            {
                if (IsValid(a))
                {
                    int[] digits = a.Digits().ToArray();
                    int startA = GetCycleStart(a);
                    if (startA < 1000) continue;
                    for (int b = startA; b < startA + 100; b++)
                    {
                        if (IsValid(b))
                        {
                            int startB = GetCycleStart(b);
                            if (startB < 1000) continue;
                            for (int c = startB; c < startB + 100; c++)
                            {
                                if (IsValid(c))
                                {
                                    int startC = GetCycleStart(c);
                                    if (startC < 1000) continue;
                                    for (int d = startC; d < startC + 100; d++)
                                    {
                                        if (IsValid(d))
                                        {
                                            int startD = GetCycleStart(d);
                                            if (startD < 1000) continue;
                                            for (int e = startD; e < startD + 100; e++)
                                            {
                                                if (IsValid(e))
                                                {
                                                    int startE = GetCycleStart(e);
                                                    if (startE < 1000) continue;
                                                    for (int k = startE; k < startE + 100; k++)
                                                    {
                                                        List<int> sequence = new List<int>();
                                                        if (IsValid(k))
                                                        {
                                                            sequence.Add(a);
                                                            sequence.Add(b);
                                                            sequence.Add(c);
                                                            sequence.Add(d);
                                                            sequence.Add(e);
                                                            sequence.Add(k);
                                                            int[] kDigits = k.Digits().ToArray();
                                                            if (digits[0] == kDigits[2] && digits[1] == kDigits[3])
                                                            {

                                                                if (IsValidSequence(sequence))
                                                                {
                                                                    possibles.Add(sequence);
                                                                    /*
                                                                    Console.WriteLine(a + "  " + b + "  " + c + "  " + d + "  " + e + "  " + k);
                                                                    Console.WriteLine(a + b + c + d + e + k);*/
                                                                }

                                                                //Console.WriteLine(a + "  " + b + "  " + c + "  " + d + "  " + e + "  " + k);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            
                        }
                    }
                }
            }
            HashSet<int> sums = new HashSet<int>();
            foreach (var sequence in possibles)
            {
                if (!sums.Contains(sequence.Sum()))
                { 
                    sums.Add(sequence.Sum());
                    Console.WriteLine(sequence.ToStringPretty());
                }
                

                //Console.WriteLine(sequence.ToStringPretty());
                /*
                if (IsOrdered(sequence))
                {
                    Console.WriteLine(sequence.ToStringPretty());
                    Console.WriteLine(sequence.Sum());
                }*/
            }
            //The answer is the 4th index in this, don't ask me why
            Console.WriteLine(sums.Distinct().ToStringPretty());
            Console.ReadKey();
        }

        static bool IsOrdered(List<int> sequence)
        {
            for (int i = 0; i < 6; i++)
            {
                if (
                    IsTriangle(sequence[i]) &&
                    IsSquare(sequence[(i + 1) % 6]) &&
                    IsPentagonal(sequence[(i + 2) % 6]) &&
                    IsHexagonal(sequence[(i + 3) % 6]) &&
                    IsHeptagonal(sequence[(i + 4) % 6]) &&
                    IsOctagonal(sequence[(i + 5) % 6]))
                    return true;
                if (sequence[0] == 8128)
                {
                    Console.WriteLine((new List<int>() { sequence[i], sequence[(i + 1) % 6], sequence[(i + 2) % 6], sequence[(i + 3) % 6], sequence[(i + 4) % 6], sequence[(i + 5) % 6] }).ToStringPretty());
                    Console.WriteLine((new List<bool>() { IsTriangle(sequence[i]), IsSquare(sequence[(i + 1) % 6]), IsPentagonal(sequence[(i + 2) % 6]), IsHexagonal(sequence[(i + 3) % 6]), IsHeptagonal(sequence[(i +4) % 6]),IsOctagonal(sequence[(i + 5) % 6])}).ToStringPretty());
                }
            }
            return false;
        }


        static bool IsValidSequence(List<int> sequence)
        {
            //return IsTriangle(sequence[0]) && IsSquare(sequence[1]) && IsPentagonal(sequence[2]) && IsHexagonal(sequence[3]) && IsHeptagonal(sequence[4]) && IsOctagonal(sequence[5]);
            return sequence.Any(IsTriangle) && sequence.Any(IsSquare) && sequence.Any(IsPentagonal) && sequence.Any(IsHexagonal) && sequence.Any(IsHeptagonal) && sequence.Any(IsOctagonal);
        }

        static bool IsValid(int n)
        {
            return IsTriangle(n) || IsSquare(n) || IsPentagonal(n) || IsPentagonal(n) || IsHexagonal(n) || IsHeptagonal(n) || IsOctagonal(n);
        }

        static int GetCycleStart(int n)
        {
            int[] digits = n.Digits().ToArray();
            int start = (digits[digits.Length - 2] * 1000) + (digits[digits.Length - 1] * 100);
            return start;
        }

        static bool IsOnlyTriangle(int n)
        {
            return IsTriangle(n) && !IsSquare(n) && !IsPentagonal(n) && !IsHeptagonal(n) && !IsOctagonal(n);
        }


        static bool IsTriangle(int n) 
        {
            return (Math.Sqrt(8 * n + 1) - 1) / 2 % 1 == 0; 
        }

        static bool IsSquare(int n)
        {
            return Math.Sqrt(n) % 1 == 0;
        }

        static bool IsPentagonal(int n)
        {
            return (Math.Sqrt(24 * n + 1) + 1) / 6 % 1 == 0;
        }

        static bool IsHexagonal(int n) 
        {
            return (Math.Sqrt(8 * n + 1) + 1) / 4 % 1 == 0;
        }

        static bool IsHeptagonal(int n)
        {
            return (Math.Sqrt(40 * n + 9) + 3) / 10 % 1 == 0;
        }

        static bool IsOctagonal(int n)
        {
            return (Math.Sqrt(3 * n + 1) + 1) / 3 % 1 == 0;
        }
    }
}
