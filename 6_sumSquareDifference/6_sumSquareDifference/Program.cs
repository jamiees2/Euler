using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6_sumSquareDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> nums = Enumerable.Range(1, 100);
            int powSum = nums.Aggregate((result, next) => result += (int)Math.Pow(next, 2));
            int sumPow = (int)Math.Pow(nums.Aggregate((result, next) => result += next), 2);
            Console.WriteLine(sumPow - powSum);
            Console.ReadKey();
        }
    }
}
