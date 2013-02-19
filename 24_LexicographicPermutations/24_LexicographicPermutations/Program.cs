using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24_LexicographicPermutations
{
    class Program
    {
        static int[] permutate = new int[] { 0, 1 ,2 ,3 ,4 ,5 ,6 ,7 ,8 ,9 };
        static void Main(string[] args)
        {
            ///Millionth position
            ///10! = 3.628.800
            ///9! = 362.880
            ///first letter has to be 2, because 362.880 * 3 > 1.000.000
            ///8! = 40.320
            ///362.880 * 2 + 40.320 * 7 > 1.000.000
            ///next letter has to be 7
            long limit = 1000000 - 1;

            //Work our way down
            List<string> letters = new List<string>();
            List<int> numbers = permutate.ToList<int>();
            for (int i = permutate.Length - 1; i > 0; i--)
            {
                long factorial = fact(i);
                long possible = limit / factorial;
                limit = limit % factorial;
                Console.Write(numbers[(int)possible]);
                numbers.RemoveAt((int)possible);
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        static long fact(int n) 
        {
            return (n == 1) ? 1 : n * fact(n - 1);
        }
    }
}
