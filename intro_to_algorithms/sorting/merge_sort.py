def merge(left_arr, right_arr, main_arr):
    left_length = len(left_arr)
    right_length = len(right_arr)
    i = 0
    j = 0
    k = 0
    while i < left_length and j < right_length:
        if left_arr[i] <= right_arr[j]:
            main_arr[k] = left_arr[i]
            i += 1
        else:
            main_arr[k] = right_arr[j]
            j += 1
        k += 1
    
    while i < left_length:
        main_arr[k] = left_arr[i]
        i += 1
        k += 1
    while j < right_length:
        main_arr[k] = right_arr[j]
        j += 1
        k += 1

def merge_sort(arr):
    n = len(arr)
    if n < 2:
        return
    mid = n / 2
    left_arr = arr[:mid]
    right_arr = arr[mid:]
    merge_sort(left_arr)
    merge_sort(right_arr)
    merge(left_arr, right_arr, arr)

arr = [3,2,1,56,3,2,7,84,8,5]
merge_sort(arr)
for i in arr:
    print(i)
