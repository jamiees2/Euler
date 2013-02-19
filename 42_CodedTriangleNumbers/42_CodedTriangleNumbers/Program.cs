using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _42_CodedTriangleNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Words = new List<string>();
            using (StreamReader reader = new StreamReader("words.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    foreach (string name in line.Split(','))
                    {
                        Words.Add(name.Substring(1, name.Length - 2));
                    }
                }
            }
            Words.Sort();
            Console.WriteLine(Words.Where(x => IsTriangle(x)).Count());
            Console.ReadKey();
        }

        static bool IsTriangle(string name)
        {
            return Math.Sqrt((8 * name.Select(x => ((long)x) - 64L).Sum()) + 1) % 1 == 0;
        }
    }
}
