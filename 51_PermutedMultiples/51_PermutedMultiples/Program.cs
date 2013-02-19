using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _51_PermutedMultiples
{
    class Program
    {
        static void Main(string[] args)
        {
            int top = 6;
            for (int i = 10; i < 1000000; i++)
            {
                if ((i * top).ToString().Length > i.ToString().Length) continue;
                bool fail = false;
                for (int j = 1; j < top + 1; j++)
                {
                    if(!IsPermutationOf(i.ToString(),(i * j).ToString())) fail = true;
                }
                if (!fail)
	            {
                    Console.WriteLine(i);
	            }
            }
            Console.ReadKey();
        }

        static bool IsPermutationOf(string first, string second)
        {
            if (second.Length > first.Length || second.Length < first.Length) return false;
            foreach (var c in first)
            {
                if (second.Count(x => x == c) != first.Count(x => x == c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
