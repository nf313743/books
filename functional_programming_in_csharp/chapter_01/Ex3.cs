// Write a method that uses quicksort to sort a List<int> (return a new list, rather
// than sorting it in place).
// evaluates to true , the resulting function evaluates to false , and vice versa.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace chapter_01
{
    [TestClass]
    public class Ex3_Test
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
        public void SortInts()
        {
            var list = new[] { 7, 3, 5 };
            var sortedList = list.GetSortedList().ToArray();
            Assert.AreNotSame(list, sortedList);
            Assert.AreEqual(3, sortedList[0]);
            Assert.AreEqual(5, sortedList[1]);
            Assert.AreEqual(7, sortedList[2]);
        }


        [TestMethod]
        public void SortString()
        {
            var list = new[] { "hello", "goodbye", "hello", "c", "z", "a" };
            var sortedList = list.GetSortedList().ToArray();
            Assert.AreNotSame(list, sortedList);
            Assert.AreEqual("a", sortedList[0]);
            Assert.AreEqual("c", sortedList[1]);
            Assert.AreEqual("goodbye", sortedList[2]);
            Assert.AreEqual("hello", sortedList[3]);
            Assert.AreEqual("hello", sortedList[4]);
            Assert.AreEqual("z", sortedList[5]);
        }
    }

    public static class Ex3
    {
        public static IList<T> GetSortedList<T>(this IList<T> list) where T : IComparable
        {
            if (!list.Any())
            {
                return new List<T>();
            }

            var newList = new List<T>(list);
            QuickSort(newList, 0, newList.Count - 1);
            return newList;
        }

        private static void QuickSort<T>(IList<T> list, int start, int end) where T : IComparable
        {
            if (start < end)
            {
                int partitionIndex = Partition(list, start, end);
                QuickSort(list, start, partitionIndex - 1);
                QuickSort(list, partitionIndex + 1, end);

            }
        }

        private static int Partition<T>(IList<T> list, int start, int end) where T : IComparable
        {
            T pivot = list[end];
            int partitionIndex = start;
            T temp;

            for (int i = start; i < end; ++i)
            {
                if (list[i].CompareTo(pivot) <= 0)
                {
                    temp = list[partitionIndex];
                    list[partitionIndex] = list[i];
                    list[i] = temp;
                    ++partitionIndex;
                }
            }

            temp = list[partitionIndex];
            list[partitionIndex] = list[end];
            list[end] = temp;
            return partitionIndex;
        }
    }
}