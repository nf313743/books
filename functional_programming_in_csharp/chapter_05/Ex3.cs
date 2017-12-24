using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_05
{
    [TestClass]
    public class Ex3_Test
    {
        [TestMethod]
        public void Compose_Test()
        {
            Func<int, int> RaiseBy10 = (x) => x * 10;
            Func<int, int> RaiseBy100 = (x) => x * 100;

            var composedFunc = RaiseBy10.Compose(RaiseBy100).Compose(x => x / 2);
            Assert.AreEqual(2500, composedFunc(5));

        }
    }
    
    public static class Ex1
    {
        public static Func<T, S> Compose<T, R, S>(this Func<T, R> func1, Func<R, S> func2)
            =>
                x => func2(func1(x));
    }
}