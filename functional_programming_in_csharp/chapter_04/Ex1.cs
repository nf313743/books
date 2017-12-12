using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace chapter_04
{
    [TestClass]
    public class Ex1_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            var opt = Some("John");
            Option<string> t = opt.Map(x=> $"Hello {x}.");
            t.ForEach(x=> Console.WriteLine(x));
            Console.WriteLine("Hello");
        }
    }
}
