using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9_PythagoreanTriplet
{
    struct Pythagorean 
    {
        public int A;
        public int B;
        public int C;

        public bool Valid() 
        {
            if (this.Product() == 0) return false;
            return Math.Pow(A, 2) + Math.Pow(B, 2) == Math.Pow(C, 2);
        }

        public int Product() 
        {
            return A * B * C;
        }

        public int Sum() 
        {
            return A + B + C;
        }

        public static int AttemptC(int A, int B)
        {
            double d = Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2));
            return (d % 1) == 0 ? (int)d : 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //a^2 + b^2 = c^2
            //a + b + c = 1000
            //Math.sqrt(a^2 + b^2)  = c
            //a && b && c are in N
            // a < b < c
            List<Pythagorean> pythagoreans = new List<Pythagorean>();
            Pythagorean p = new Pythagorean { A = 0,B = 0, C = 0 };
                for (int b = 2; b < 1000; b++)
                {
                    for (int a = 1; a < b; a++)
                    {
                        p = new Pythagorean
                        {
                            A = a,
                            B = b,
                            C = Pythagorean.AttemptC(a,b)
                        };
                        if (p.Valid() && p.Sum() == 1000) pythagoreans.Add(p);
                        //if (p.Valid() && p.Sum() == 1000) break;
                    }
                }
            
            foreach (var item in pythagoreans)
            {
                Console.WriteLine(item.Product());
            }
            Console.ReadKey();
        }
    }
}
