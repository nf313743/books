using System;
using LaYumba.Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LaYumba.Functional.F;

// Write a generic function that takes a string and parses it as a value of an enum. It
// should be usable as follows:
// Enum.Parse<DayOfWeek>("Friday") // => Some(DayOfWeek.Friday)
// Enum.Parse<DayOfWeek>("Freeday") // => None
namespace chapter03
{
    public enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    [TestClass]
    public class Ex1_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(Some(DayOfWeek.Monday), Enum.Parse<DayOfWeek>("Monday"));
            Assert.AreEqual(None, Enum.Parse<DayOfWeek>("Funday"));
        }
    }

    public static class Enum
    {
        public static Option<T> Parse<T>(string value) where T : struct
            => System.Enum.TryParse<T>(value, out T result)
                    ? Some(result)
                    : None;
        

        public static bool IsEmpty(this string @this)
        {
            return true;
        }
    }
}
