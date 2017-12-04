def insertion_sort(arr):
    i = 1
    arr_length = len(arr)
    while i <= arr_length - 1:
        value = arr[i]
        hole = i
        while hole > 0 and arr[hole - 1] > value:
            arr[hole] = arr[hole - 1]
            hole -= 1
        arr[hole] = value
        i += 1

arr = [5,4,3,2,1]
insertion_sort(arr)
for i in arr:
    print(i)
