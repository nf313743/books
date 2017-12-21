using System;
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
        }
    }
}
