import unittest


class QuickSortTest(unittest.TestCase):
    def setUp(self):
        self.quick_sort = QuickSort()

    def test_sort(self):
        test_list = [7, 3, 4]
        self.quick_sort.quick_sort(test_list, 0, 2)
        self.assertEqual(3, test_list[0])
        self.assertEqual(4, test_list[1])
        self.assertEqual(7, test_list[2])

    def test_sort2(self):
        test_list = [-100, 63, 30, 45, 1, 1000, -23, -67, 1, 2, 56, 75, 975, 432, -600, 193, 85, 12]
        expected = [-600, -100, -67, -23, 1, 1, 2, 12, 30, 45, 56, 63, 75, 85, 193, 432, 975, 1000]
        self.quick_sort.quick_sort(test_list, 0, len(test_list) -1)
        self.assertListEqual(expected, test_list)


class QuickSort:

    def partition(self, arr, start, end):
        pivot = arr[end]
        partition_index = start

        for i in range(start, end):
            if arr[i] <= pivot:
                self.swap(arr, i, partition_index)
                partition_index += 1

        self.swap(arr, partition_index, end)
        return partition_index

    def quick_sort(self, arr, start, end):
        if start < end:
            partition_index = self.partition(arr, start, end)
            self.quick_sort(arr, start, partition_index - 1)
            self.quick_sort(arr, partition_index + 1, end)

    def swap(self, arr, index1, index2):
        temp = arr[index1]
        arr[index1] = arr[index2]
        arr[index2] = temp


if __name__ == '__main__':
    unittest.main()
