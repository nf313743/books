// Write a Lookup function that will take an IEnumerable and a predicate, and
// return the first element in the IEnumerable that matches the predicate, or None
// if no matching element is found. Write its signature in arrow notation:
// bool isOdd(int i) => i % 2 == 1;
// new List<int>().Lookup(isOdd) // => None
// new List<int> { 1 }.Lookup(isOdd) // => Some(1)
using System;
using System.Collections.Generic;
using System.Linq;
using LaYumba.Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LaYumba.Functional.F;

namespace chapter03
{


    [TestClass]
    public class Ex2_Test
    {
        [TestMethod]
        public void EmptyList_ReturnNone()
        {
            Assert.AreEqual(None, new List<int>().Lookup(Ex2.IsOdd));

        }
        [TestMethod]
        public void HasNoMatches_ReturnNone()
        {
            Assert.AreEqual(None, new List<int>() { 1, 3, 5 }.Lookup(Ex2.IsOdd));
        }

        [TestMethod]
        public void HasMatch_ReturnSome()
        {
            Assert.AreEqual(Some(4), new List<int>() { 1, 3, 4, 5, 6 }.Lookup(Ex2.IsOdd));
        }

        [TestMethod]
        public void SplitDownMiddle()
        {
            var result = Ex2.SplitDownMiddleLowerNoSpaces("Anna");
            Assert.AreEqual("an", result.Item1);
            Assert.AreEqual("na", result.Item2);
            
            result = Ex2.SplitDownMiddleLowerNoSpaces("Level");
            Assert.AreEqual("le", result.Item1);
            Assert.AreEqual("el", result.Item2);

            result = Ex2.SplitDownMiddleLowerNoSpaces("tet");
            Assert.AreEqual("t", result.Item1);
            Assert.AreEqual("t", result.Item2);
        }

        [TestMethod]
        public void MatchPalindrome_None()
        {
            Assert.AreEqual(None, new List<string>{"hello", "gelle"}.Lookup(Ex2.IsPalindrome));
        }

        [TestMethod]
        public void MatchPalindrome_Some()
        {
            Assert.AreEqual(Some("A Santa dog lived as a devil God at NASA"), 
                        new List<string>{"hello", "A Santa dog lived as a devil God at NASA"}
                                        .Lookup(Ex2.IsPalindrome));
        }
    }

    public static class Ex2
    {
        public static Predicate<int> IsOdd => (i) => i % 2 == 0;


        public static Predicate<string> IsPalindrome
            => (s) =>
            {
                var (left, right) = SplitDownMiddleLowerNoSpaces(s);
                return left == new string(right.Reverse().ToArray());
            };

        public static (string, string) SplitDownMiddleLowerNoSpaces(string val)
        {
            string lowerNoSpaces = val.Replace(" ", "").ToLowerInvariant();
            int middle = lowerNoSpaces.Length / 2;
            string left = lowerNoSpaces.Substring(0, middle);
            string right = lowerNoSpaces.Substring(lowerNoSpaces.Length % 2 == 0 ? middle : middle + 1);
            return (left, right);
        }

        public static Option<T> Lookup<T>(this IEnumerable<T> @this, Predicate<T> pred)
        {
            foreach (var v in @this)
            {
                if (pred(v))
                    return Some(v);
            }
            return None;
        }
    }
}