// Write a function that negates a given predicate: whenever the given predicate
// evaluates to true , the resulting function evaluates to false , and vice versa.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_01
{
    [TestClass]
    public class Ex2_Test
    {
        [TestMethod]
        public void IsEven()
        {
            Assert.IsTrue(Ex2.IsEven(10));
            Assert.IsFalse(Ex2.IsEven(11));
        }

        [TestMethod]
        public void Negate()
        {
            var isEvenNeg = Ex2.Negate(Ex2.IsEven);
            Assert.IsFalse(isEvenNeg(10));
            Assert.IsTrue(isEvenNeg(11));
        }
    }

    public class Ex2
    {
        public static Func<int, bool> IsEven 
            => x => x % 2 == 0;

        public static Func<T, bool> Negate<T>(Func<T, bool> pred) 
            => x => !pred(x);
    }
}
