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

            foreach(var i in  Enumerable.Range(1, 8))
            {Console.WriteLine(i);
            }
        }
    }
}
