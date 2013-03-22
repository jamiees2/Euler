using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pie.IO;

namespace _99_LargestExponential
{
    class Program
    {
        static void Main(string[] args)
        {
            double max = 0;
            double maxLog = 0;
            using (StreamReader reader = new StreamReader("exp.txt"))
            {
                string line;
                var i = 1;
                while ((line = reader.ReadLine()) != null)
                {
                    var lines = line.Split(',');
                    var b = int.Parse(lines[0]);
                    var e = int.Parse(lines[1]);
                    double log = e*Math.Log(b);
                    if (log > maxLog)
                    {
                        maxLog = log;
                        max = i;
                    }
                    i++;
                }
            }
            Console.WriteLine(max);
            Console.ReadKey();
        }
    }
}
