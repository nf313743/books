using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using System.Collections.Generic;
using System.Linq;

namespace chapter_04
{
    [TestClass]
    public class Ex1_Test
    {
        [TestMethod]
        public void TestSet()
        {
            var set = new HashSet<int>(Enumerable.Range(1,9));
            var resultSet = set.Map((x=> x * 10));
            Assert.AreEqual(450, resultSet.Sum());
        }

        [TestMethod]
        public void TestDict()
        {
            var dict = new Dictionary<string, string>
            {
                {"one", "1"},
                {"two", "2"},
                {"three", "3"}
            };

            var resultDict = dict.Map(x => int.Parse(x));
            Assert.AreEqual(1, resultDict["one"]);
            Assert.AreEqual(3, resultDict["three"]);
        }
    }

    public static class Ext
    {
        
        public static ISet<R> Map<T, R>(
            this ISet<T> @this, Func<T, R> func)
        {
            var set = new HashSet<R>();
            foreach(var t in @this)
                set.Add(func(t));
            return set;
        }

        public static IDictionary<K, R> Map<K, S, R>(
            this IDictionary<K, S> @this, Func<S, R> func)
            {
                var dict = new Dictionary<K, R>();
                foreach(var pair in @this)
                {
                    dict.Add(pair.Key, func(pair.Value));
                }
                return dict;
            }
        
    }
}
