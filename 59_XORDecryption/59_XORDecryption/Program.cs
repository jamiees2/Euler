using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _59_XORDecryption
{
    static class IEnumerableExtensions 
    {
        public static IEnumerable<T> NthRange<T>(this IEnumerable<T> list, int step, int skip = 0)
        {
            return list.Skip(skip).Where((x, i) => i % step  == 0);
        }

        public static T OccurringElement<T>(this IEnumerable<T> elements) 
        {
            return elements.GroupBy(d => d).OrderByDescending(e => e.Count()).First().First();
        }
    }
    class Program
    {
        static int[] values = null;
        static void Main(string[] args)
        {
            //26^3 possibilities
            //Console.WriteLine(Math.Pow(26,3) + " possibilities");
            ReadFile();
            //The space is the most often occurring character in english
            int keyLength = 3;
            char space = ' ';
            

            string key = "";
            for (int i = 0; i < keyLength; i++)
            {
                key += CryptXOR((char)values.NthRange(keyLength, i).OccurringElement(), space);
            }
            Console.WriteLine(values.Select((x,i) => CryptXOR((char)x,key[i % keyLength])).Aggregate("",(result, next) => result += next));
            Console.WriteLine("Sum of ASCII codes: " + values.Select((x,i) => (int)CryptXOR((char)x,key[i % keyLength])).Sum());
            
            
            Console.ReadKey();
        }

        static void ReadFile() 
        {
            using (StreamReader reader = new StreamReader("cipher1.txt"))
            {
                List<string> vals = new List<string>();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    vals.AddRange(line.Split(','));
                }
                values = vals.Select(x => Int32.Parse(x)).ToArray();

            }
        }

        

        static char CryptXOR(char a, char b) 
        {
            return (char)((byte)a ^ (byte)b);
        }
    }
}
