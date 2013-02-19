using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _19_CountingSundays
{
    class Program
    {
        static int[] normalYear = new int[]{ 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        static int[] leapYear = new int[]{ 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        static string[] days = new string[] { "Sun", "Mon","Tue", "Wed", "Thu", "Fri", "Sat" };
        static void Main(string[] args)
        {
            int startingDate = 2 ;
            int dateCount = 0;
            bool leap = false;
            int year;
            for (int i = 1; i <= 100; i++)
            {
                
                year = 1900 +  i;
                leap = (year % 100 == 0) ? (year % 400 == 0) : (year % 4 == 0);
                Console.WriteLine(year + "  " + leap + " " + startingDate);
                dateCount += FindMonthsStartWith(startingDate, 0, leap);
                startingDate = (leap ? startingDate + 2 : startingDate + 1) % 7;
            }
            Console.WriteLine(dateCount);
            Console.ReadKey();
        }

        static int FindMonthsStartWith(int startingDate, int date ,bool leap)
        {
            int dateCount = (startingDate == date) ? 1 : 0 ;
            //Console.WriteLine(days[startingDate]);
            int[] year = (leap) ? leapYear : normalYear;
            int monthSum = startingDate;
            for (int i = 0; i < year.Length - 1; i++)
            {
                monthSum += year[i];
                //Console.WriteLine(days[monthSum % 7]);
                if (monthSum % 7 == date)
                {
                    dateCount++;
                }
            }
            //Console.WriteLine(dateCount);
            return dateCount;
        }
    }
}
