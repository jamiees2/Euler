using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _22_NameScores
{
    class Program
    {

        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            using (StreamReader reader = new StreamReader("names.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    foreach (string name in line.Split(','))
                    {
                        names.Add(name.Substring(1,name.Length - 2));
                    }
                }
            }
            names.Sort();
            Console.WriteLine(names.Select((x, i) => ComputeNameScore(x, i + 1)).Sum()); 
            Console.ReadKey();
        }

        static long ComputeNameScore(string name, int index) 
        {
            return name.Select(x => ((long)x) - 64L).Sum() * index;
        }
    }
}
