def selection_sort(arr):
    i = 0
    j = 0
    while i < len(arr) -1:
        min_element = i
        j= i + 1
        while j  < len(arr):
            if arr[j] < arr[min_element]:
                min_element = j
            j += 1    

        temp = arr[i]
        arr[i] = arr[min_element]
        arr[min_element] = temp
        i += 1

unsorted_list = [3,6,2,9,4,8]
selection_sort(unsorted_list)
for i in unsorted_list:
    print(i)