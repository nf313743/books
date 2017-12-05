using System;
using static System.Console;
using static System.Math;

namespace Chapter2
{
    public static class Bmi
    {
        public static void Run(Func<string, double> read, Action<string> write)
        {
            double weight = read("weight");
            double height = read("height");
            double bmiResult = CalculateBmi(weight, height);
            string msg = CreateMessage(bmiResult);;
            write(msg);
        }

        public static double Read(string msg)
        {
            Write($"Enter your {msg}: ");
            double result = double.Parse(ReadLine());
            WriteLine();
            return result;
        }

        public static double CalculateBmi(double weight, double height)
            => Round(weight * Pow(height, 2), 2);

            public static string CreateMessage(double bmi)
            
            {
                if(18.5 > bmi)
                    return "Underweight";
                else if (bmi >= 25)
                    return "Overwieght";
                return "Healthy";
            }

            public static Action<string> Write
                => (s) => WriteLine($"You are {s}");
    }
}