using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using SharpBag.Strings;
using SharpBag;

namespace _55_LychrelNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan t = Utils.ExecutionTime(() =>
                {
                    int count = 0;
                    for (int i = 0; i < 10000; i++)
                    {
                        if (IsLychrel(i)) count++;
                        //else Console.WriteLine(i);
                    }
                    Console.WriteLine(count);
                });
            Console.WriteLine("Solution found in " + t.Milliseconds + "ms");
            Console.ReadKey();
        }

        static bool IsPalindrome(BigInteger n) 
        {
            return IsPalindrome(n.ToString());
        }

        static bool IsPalindrome(string nString)
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

        static Dictionary<BigInteger, bool> cache = new Dictionary<BigInteger, bool>();
        static bool IsLychrel(BigInteger n) 
        {
            bool tryVal = false;
            if (cache.TryGetValue(n, out tryVal)) return tryVal;

            BigInteger c = n;
            int i = 0;
            do
            {
                c += Reverse(c);
                i++;
            } while (!IsPalindrome(c) && i < 50);
            if (i >= 50) 
            {
                cache.Add(n,true);
                BigInteger reversed = Reverse(n);
                if (!cache.ContainsKey(reversed)) cache.Add(reversed, true);
                return true;
            }
            return false;
        }

        static BigInteger Reverse(BigInteger n) 
        {
            //Console.WriteLine(new string(n.ToString().Reverse().ToArray()));
            return BigInteger.Parse(n.ToString().Reverse());
        }
    }
}
