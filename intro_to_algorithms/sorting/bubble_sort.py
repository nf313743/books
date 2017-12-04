def bubble_sort(arr):
    i = 0
    arr_length = len(arr)
    while i < arr_length -1:
        flag = False
        j = 0
        while j < arr_length - i - 1:
            if arr[j] > arr[j+1]:
                flag = True
                temp = arr[j]
                arr[j] = arr[j + 1]
                arr[j + 1] = temp
            j += 1
        if not flag:
            return
        i += 1
            
unsorted_list = [3,6,2,9,4,8]
bubble_sort(unsorted_list)
for i in unsorted_list:
    print(i)

sorted_list = [1 , 3, 5 ,7]
bubble_sort(sorted_list)
for i in sorted_list:
    print(i)
