using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using System.Collections.Generic;
using System.Linq;

namespace chapter_04
{
    /*
    Implement Map for Option and IEnumerable in terms of Bind and Return.

    Map : (C<T>, (T -> R)) -> C<R>
    Bind : (C<T>, (T -> C<R>)) -> C<R>
    Return : T -> C<T>
     */

    [TestClass]
    public class Ex2_Test
    {
        [TestMethod]
        public void TestOptionMap()
        {
            Option<int> result = Some("100").Map(x => int.Parse(x));
            Assert.AreEqual(Some(100), result);
        }

        [TestMethod]
        public void TestOptionIEnumerable()
        {
            var list = new List<int> { 1, 2, 3 };
            var resultList = list.Map(x => x.ToString()).ToList();
            var resultList2 = list.Map2(x => x.ToString()).ToList();
            Assert.AreEqual("3", resultList[2]);
        }
    }

    public static class Ext2
    {
        public static Option<R> Map<T, R>(this Option<T> opt, Func<T, R> func)
            => opt.Bind(x => Some(func(x)));

        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> ts, Func<T, R> func)
            => ts.Bind(x => Some(func(x)));

        public static Option<R> Map2<T, R>(this Option<T> opt, Func<T, R> f)
            => opt.Bind(t => Some(f(t)));

        public static IEnumerable<R> Map2<T, R>(this IEnumerable<T> ts, Func<T, R> f)
            => ts.Bind(t => List(f(t)));
    }
}
