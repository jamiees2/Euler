using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _18_MaxPathSumI
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] inputTriangle = readInput("triangle.txt");
            int lines = inputTriangle.GetLength(0);

            for (int i = lines - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    inputTriangle[i, j] += Math.Max(inputTriangle[i + 1, j], inputTriangle[i + 1, j + 1]);
                }
            }
            int tempSum = 0;
            for (int i = 0; i < inputTriangle.GetLength(1); i++) tempSum += inputTriangle[0, i];
            Console.WriteLine(tempSum);
            Console.ReadKey();
        }

        static int[,] readInput(string filename)
        {
            string line;
            string[] linePieces;
            int lines = 0;
            int[,] inputTriangle = null;
            using (StreamReader r = new StreamReader(filename))
            {
                while ((line = r.ReadLine()) != null)
                {
                    lines++;
                }

                inputTriangle = new int[lines, lines];
                r.BaseStream.Seek(0, SeekOrigin.Begin);

                int j = 0;
                while ((line = r.ReadLine()) != null)
                {
                    linePieces = line.Split(' ');
                    for (int i = 0; i < linePieces.Length; i++)
                    {
                        inputTriangle[j, i] = int.Parse(linePieces[i]);
                    }
                    j++;
                }
            }
            return inputTriangle;
        }
    }
}
