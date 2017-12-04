import unittest

class QuickSortTest(unittest.TestCase):
    def setUp(self):
        self.quick_sort = QuickSort()

    def test_sort(self):
        l = [7, 3, 4]
        self.quick_sort.quick_sort(l, 0, 2)
        self.assertEqual(3, l[0])
        self.assertEqual(4, l[1])
        self.assertEqual(7, l[2])

class QuickSort:
    
    def partition(self, arr, start, end):
        pivot = end
        partitionIndex = start

        for i in range(len(arr)):
            if arr[i] <= pivot:
                self.swap(arr, i, partitionIndex)
                partitionIndex += 1
               
        self.swap(arr, partitionIndex, end)
        return partitionIndex

    def quick_sort(self, arr, start, end):
        if start < end:
            partitionIndex = self.partition(arr, start, end)
            self.quick_sort(arr, start, partitionIndex -1)
            self.quick_sort(arr, partitionIndex + 1, end)

    def swap(self, arr, index1, index2):
        temp = arr[index1]
        arr[index1] = arr[index2]
        arr[index2] = temp

        
if __name__ == '__main__':
    unittest.main()