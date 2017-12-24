using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_05
{
    [TestClass]
    public class AverageEarningsExt_Test
    {
        [TestMethod]
        public void AverageEarnings_Test()
        {
            Assert.AreEqual(75000, Person.GetSampleData().RichestQuartile().AverageEarnings());
        }
    }

    public static class AverageEarningsExt
    {
        public static IEnumerable<Person> RichestQuartile(this IEnumerable<Person> list)
        {
            return list
                    .OrderByDescending(x => x.Earnings)
                    .Take(list.Count() / 4);
        }

        public static decimal AverageEarnings(this IEnumerable<Person> list)
        {
            return list.Average(x => x.Earnings);
        }
    }

    public class Person
    {

        public static List<Person> GetSampleData() =>
            Enumerable.Range(1, 8)
            .Select(x => new Person { Earnings = x * 10000 })
            .ToList();

        public decimal Earnings { get; set; }
    }
}
