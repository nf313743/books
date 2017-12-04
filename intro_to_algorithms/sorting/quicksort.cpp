#include<iostream>
using namespace std;

int partition(int *arr, int start, int end)
{
    int pivot = A[end];
    int partitionIndex = start;
    for(int i = start; i < end; ++i)
    {
        if(A[i] <= pivot)
        {
            swap(A[i], A[partitionIndex]);
            ++partitionIndex;
        }
    }
    swap(A[partitionIndex], A[end]);
    return partitionIndex;
}

void QuickSort(int *A, int start, int end)
{
    if(start < end)
    {
        int partitionIndex = partition(A, start, end);
        QuickSort(A, start, partitionIndex -1);
        QuickSort(A, partitionIndex + 1, end);

    }
}

int main()
{
    int A[] = {7,2,1,6,8,5,3,4};
    QuickSort(A,0,7);
    for(int i  = 0; i < 8; ++i)
    {
        cout << A[i] << " ";
    }
}