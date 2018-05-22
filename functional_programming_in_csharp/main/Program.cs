using System;
using System.Linq;
using Examples.Chapter3;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace main
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "66";
            Option<int> optI = Int.Parse(input);
            var ageOpt = optI.Map(i => Age.Of(i));
            var ageOpt1 = optI.Bind(i => Age.Of(i));

            // Taking an option, applying a function that returns an option
            // and return that result
            var result = optI.Bind(x => Some(x));
            
            // Taking an option, applying a function that can return anything
            // return the result wrapping in an Option.
            var result2 = optI.Map(x => x);

        
           Calc(3, 0)
           .Bind(Calc(3,3))
           .Match(
              x=> Console.WriteLine(x),
              y => Console.WriteLine(y)
           );
        }

        static Either<string, double> Calc(double x, double y)
        {
            if(y == 0)
            {
                return "y cannot be 0";
            }

            if(x!=0 && Math.Sign(x) != Math.Sign(y))
            {
                return "x / y cannot be negative";
            }

            return Math.Sqrt( x / y);
        }
    }
}
