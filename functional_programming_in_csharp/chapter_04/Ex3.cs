/*
Use Bind and an Option-returning Lookup function (such as the one we defined
in chapter 3) to implement GetWorkPermit, shown below. Then enrich the
implementation so that GetWorkPermit returns None if the work permit has
expired.

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
    public class Ex3_Test
    {
        Dictionary<string, Employee> _employees;

        [TestInitialize]
        public void Setup()
        {
            _employees = TestData.GetEmployees();
        }

        [TestMethod]
        public void GetWorkPermit_Valid()
        {
            var result = Ex3.GetWorkPermit(_employees, "Nathan");
            var permit = result.Match(
                () => new WorkPermit(),
                (x) => x);

            Assert.AreEqual(new DateTime(2080, 1, 1), permit.Expiry);
        }

        [TestMethod]
        public void GetWorkPermit_Expired()
        {
            var result = Ex3.GetWorkPermit(_employees, "Tom");
            Assert.AreEqual(None, result);
        }
    }

    static class Ext4
    {
        static Option<T> Lookup<K, T>(this IDictionary<K, T> dict, K key)
        {

            return dict.TryGetValue(key, out T value)
                    ? Some(value)
                    : None;
        }
    }

    public static class Ex3
    {
        public static Option<WorkPermit> GetWorkPermit(Dictionary<string, Employee> people, string employeeId)
            => people.Lookup(employeeId)
                        .Bind(x => x.WorkPermit)
                        .Match(
                            () => None,
                            (s) => s.Expiry < DateTime.Now
                                    ? None
                                    : Some(s));

    }
}
