using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag.Strings;
using SharpBag.Math;

namespace _75_SingularIntegerRightTriangles
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 1500000;
            int result = 0;
            long[] pythagoreans = new long[limit];
            for (int m = 2; m < Math.Sqrt(limit); m++)
            {
                for (int n = 1; n < m; n++)
                {
                    if ((m + n) % 2 == 1 && BagMath.Gcd(m,n) == 1)
                    {
                        long a = (long)(Math.Pow(m,2) - Math.Pow(n,2));
                        long b = (long)(2 * m * n);
                        long c = (long)(Math.Pow(m, 2) + Math.Pow(n, 2));
                        long primitive = a + b + c;
                        while (primitive < limit)
                        {
                            pythagoreans[primitive]++;
                            if (pythagoreans[primitive] == 1)
                            {
                                result++;
                            }
                            if (pythagoreans[primitive] == 2)
                            {
                                result--;
                            }
                            primitive += a + b + c;
                        }
                    }
                    //Console.WriteLine(m + " " + n + "     " + a + " " + b + " " + c + " " + (a + b + c));
                }
            }
            //Generate the non-primitives
            /*
            HashSet<int[]> pythagoreans = new HashSet<int[]>(primitives);
            foreach (var primitive in primitives)
            {
                int i = 2;
                int[] current = new int[3];
                while (current.Sum() < limit)
                {
                    current = new int[] { primitive[0] * i, primitive[1] * i, primitive[2] * i };
                    if (!pythagoreans.Contains(current))
                    {
                        pythagoreans.Add(current);
                    }
                    i++;
                }
            }*/
            /*
            int res = 0;
            Dictionary<long, int> result = new Dictionary<long, int>();
            foreach (var sum in pythagoreans)
            {
                if (!result.ContainsKey(sum))
                {
                    result.Add(sum, 0);
                }
                result[sum]++;
                if (result[sum] == 1)
                {
                    res++;
                }
                if (result[sum] == 2)
                {
                    res--;
                }
            }*/
            //DO NOT UNCOMMENT
            //Console.WriteLine(result.ToStringPretty());
            //Answer: 161667
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
