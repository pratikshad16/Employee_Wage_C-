using System;
using System.Collections.Generic;

namespace Employee_Wage
{
    class Employee
    {
        // Constants
        int WAGE_PER_HOUR = 20;
        int FULL_DAY_HOUR = 8;
        int PART_TIME_HOUR = 4;
        int ABSENT_DAY_HOUR = 0;
        int MONTHLY_DAY = 20;

        // Variables
        int totalWagePerDay = 0;
        int dailyWageFulltime = 0;
        int dailyWageParttime = 0;
        int dailyWageAbsent = 0;
        int day = 1;
        int workingHours = 0;
        int workHours = 0;

        // Creating a dictionary using Dictionary<TKey,TValue> class
        Dictionary<int, int> EmpDailyWageKV = new Dictionary<int, int>();

        // Calulating workhours in function
        public int totalWorkingHours(int hours)
        {
            workHours += hours;
            return workHours;
        }

        public void dailyWageDict(int days, int dailyWage)
        {
            // Adding key/value pairs in the Dictionary Using Add() method
            EmpDailyWageKV.Add(days, dailyWage);
        }

        public int attendanceCheck()
        {
            while (day <= MONTHLY_DAY && workingHours <= 100)
            {
                Random random = new Random();
                int attendanceRandom = random.Next(3);

                switch (attendanceRandom)
                {
                    case 1:
                        dailyWageFulltime = WAGE_PER_HOUR * FULL_DAY_HOUR;
                        totalWagePerDay = totalWagePerDay + dailyWageFulltime;
                        dailyWageDict(day, dailyWageFulltime);
                        workingHours = totalWorkingHours(FULL_DAY_HOUR);
                        break;
                    case 2:
                        dailyWageParttime = WAGE_PER_HOUR * PART_TIME_HOUR;
                        totalWagePerDay = totalWagePerDay + dailyWageParttime;
                        dailyWageDict(day, dailyWageParttime);
                        workingHours = totalWorkingHours(PART_TIME_HOUR);
                        break;
                    case 0:
                        dailyWageAbsent = WAGE_PER_HOUR * ABSENT_DAY_HOUR;
                        totalWagePerDay = totalWagePerDay + dailyWageAbsent;
                        dailyWageDict(day, dailyWageAbsent);
                        workingHours = totalWorkingHours(ABSENT_DAY_HOUR);
                        break;
                }
                day += 1;
            }
            Console.WriteLine("Total Working Hours: " + workingHours);

            // Display keys and values from dictionary to console screen.
            foreach (KeyValuePair<int, int> wage in EmpDailyWageKV)
            {
                Console.WriteLine("Day:{0}  Wage: {1}", wage.Key, wage.Value);
            }
            return totalWagePerDay;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int monthlyWage;
            Console.WriteLine("Welcome to Employee Wage Program!");
            Employee e1 = new Employee();
            monthlyWage = e1.attendanceCheck();
            Console.WriteLine("Monthly wage of emp: " + monthlyWage);
        }
    }
}
