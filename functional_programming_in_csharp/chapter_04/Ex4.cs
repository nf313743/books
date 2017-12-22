/*
Use Bind to implement AverageYearsWorkedAtTheCompany, shown below (only
employees who have left should be included).

Map : (C<T>, (T -> R)) -> C<R>
Bind : (C<T>, (T -> C<R>)) -> C<R>
Return : T -> C<T>
*/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using System.Collections.Generic;
using System.Linq;

namespace chapter_04
{
    [TestClass]
    public class Ex4_Test
    {
        List<Employee> _employees;
        
        [TestInitialize]
        public void Setup()
        {
          _employees = TestData.GetEmployees().Values.ToList();
        }

        [TestMethod]
        public void TestAveragedYearsWorked()
        {
            Assert.AreEqual(13.6, Math.Round(Ex4.AverageYearsWorkedAtTheCompany(_employees), 1));
        }
    }

    public static class Ex4
    {
        public static double AverageYearsWorkedAtTheCompany(List<Employee> employees)
            => employees.Bind(x => x.LeftOn.Map(leftOn => YearsBetween(x.JoinedOn, leftOn)))
                        .Average();

        public static double YearsBetween(DateTime start, DateTime end)
            => (end - start).Days / 365d;
    }

}