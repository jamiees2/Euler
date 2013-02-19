using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _14_LongestCollatz
{
    class Program
    {
        static void Main(string[] args)
        {
            const int number = 1000000;

            int sequenceLength = 0;
            int startingNumber = 0;
            long sequence;

            int[] cache = new int[number + 1];
            //Initialise cache
            for (int i = 0; i < cache.Length; i++)
            {
                cache[i] = -1;
            }
            cache[1] = 1;

            for (int i = 2; i <= number; i++)
            {
                sequence = i;
                int k = 0;
                while (sequence != 1 && sequence >= i)
                {
                    k++;
                    if ((sequence % 2) == 0)
                    {
                        sequence = sequence / 2;
                    }
                    else
                    {
                        sequence = sequence * 3 + 1;
                    }
                }
                //Store result in cache
                cache[i] = k + cache[sequence];

                //Check if sequence is the best solution
                if (cache[i] > sequenceLength)
                {
                    sequenceLength = cache[i];
                    startingNumber = i;
                }
            }
            Console.WriteLine(startingNumber + "  " + sequenceLength);
            Console.ReadKey();
        }
        static List<int> Collatz(int startingPoint) 
        {
            List<int> sequence = new List<int>();
            int number = startingPoint;
            while (true)
            {
                sequence.Add(number);
                if (number == 1) break;
                if ((number % 2) == 0) number = number / 2;
                else number = (3 * number) + 1;
            }
            return sequence;
        }
    }
}
