using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _26_reciprocalCycles
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequenceLength = 0;
            int highestI = 0;
            for (int i = 1000; i > 1; i--)
            {
                if (sequenceLength >= i)
                {
                    break;
                }

                int[] foundRemainders = new int[i];
                int value = 1;
                int position = 0;

                while (foundRemainders[value] == 0 && value != 0)
                {
                    foundRemainders[value] = position;
                    value *= 10;
                    value %= i;
                    position++;
                }

                if (position - foundRemainders[value] > sequenceLength)
                {
                    sequenceLength = position - foundRemainders[value];
                    highestI = i;
                }
            }
            Console.WriteLine(highestI);
            Console.ReadKey();
        }

    }
}
