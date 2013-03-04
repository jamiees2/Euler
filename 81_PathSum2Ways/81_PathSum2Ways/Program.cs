using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Strings;
using System.IO;

namespace _81_PathSum2Ways
{
    class Program
    {
        
        static int[,] matrix = new int[80, 80];
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("matrix.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                int[] numbers = lines[i].Split(',').Select(Int32.Parse).ToArray();
                for (int j = 0; j < numbers.Length; j++)
                {
                    matrix[i,j] = numbers[j];
                }
            }
            //Start at the end (331)
            //Add the number to the left with the start, and the number to the top
            //Select the lower of the sums
            //Repeat

            int a = matrix.GetLength(0) - 1;
            //Calculate the bottom row, and the far right row
            for (int i = a - 1; i >= 0; i--)
            {
                matrix[a, i] += matrix[a, i + 1];
                matrix[i, a] += matrix[i + 1, a];
            }
            //Now find the minimum path
            for (int i = a - 1; i >= 0; i--)
            {
                for (int j = a - 1; j >= 0; j--)
                {
                    matrix[i, j] += Math.Min(matrix[i + 1, j], matrix[i, j + 1]);
                }
            }
            /*
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.Write("\n");
            }*/
            Console.WriteLine(matrix[0,0]);
            Console.ReadKey();
        }
    }
}
