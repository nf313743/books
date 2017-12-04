// Generalize the previous implementation to take a List<T>, and additionally a
// Comparison<T> delegate
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_01
{
    [TestClass]
    public class Ex4_Test
    {
        [TestMethod]
        public void EmptyList()
        {
            var emptyList = new List<int>();
            var sortedList = emptyList.GetSortedList();
            Assert.IsFalse(sortedList.Any());
            Assert.AreNotSame(emptyList, sortedList);
        }

        [TestMethod]
        public void TestQuickSort()
        {
            var list = new List<int> { -100, 63, 30, 45, 1, 1000, -23, -67, 1, 2, 56, 75, 975, 432, -600, 193, 85, 12 };
            var expected = new List<int> { -600, -100, -67, -23, 1, 1, 2, 12, 30, 45, 56, 63, 75, 85, 193, 432, 975, 1000 };
            
            Comparison<int> comparer = (x,y) =>
            {
                if(x < y)
                {
                    return -1;
                }
                else if (x == y)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            };
            var actual = list.QuickSort(comparer);
            CollectionAssert.AreEqual(expected, actual);
        }
    }

    public static class Ex4
    {
        public static List<T> QuickSort<T>(this List<T> list, Comparison<T> compare)
        {
            if (list.Count == 0) return new List<T>();

            var pivot = list[0];
            var rest = list.Skip(1);

            var small = from item in rest where compare(item, pivot) <= 0 select item;
            var large = from item in rest where compare(item, pivot) > 0 select item;

            return small.ToList().QuickSort(compare)
               .Append(pivot)
               .Concat(large.ToList().QuickSort(compare))
               .ToList();
        }
    }
}
