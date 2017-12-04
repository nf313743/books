#include <iostream>
using namespace std;

class CircularQueue
{
    public:
        CircularQueue(int arraySize);
        ~CircularQueue();
        int pop();
        int peek();
        void push(int value);
        bool isEmpty();
        void print();
    private:
        int *arr;
        int frontIndex;
        int backIndex;
        int arraySize;
};

CircularQueue::CircularQueue(int arraySize)
{
    arr = new int [arraySize];
    this->arraySize = arraySize;
    frontIndex = -1;
}

CircularQueue::~CircularQueue()
{
    delete[] arr;
}

void CircularQueue::print()
{
    for(int i = 0; i < arraySize; ++i)
    {
      cout << arr[i] << " ";
    }
    cout << endl;
}

int CircularQueue::pop()
{
    if(isEmpty())
    {
        return -1;
    }

    int value = arr[frontIndex];
    
    if(frontIndex == backIndex)
    {
        // We just popped the last element.
        frontIndex = -1;
    }
    else
    {
        frontIndex = (frontIndex + 1) % arraySize;
    }
    return value;
}

int CircularQueue::peek()
{
    if(isEmpty())
        return -1;

    return arr[frontIndex];
}

void CircularQueue::push(int value)
{
    if(isEmpty())
    {
        frontIndex = 0;
        backIndex = 0;
    }
    else
    {
        backIndex = (backIndex + 1) % arraySize;
        if(backIndex == frontIndex)
        {   
            // increment the front index. We're going to overwrite the old front.
             frontIndex = (frontIndex + 1) % arraySize;
        }
    }
    
    arr[backIndex] = value;
}

bool CircularQueue::isEmpty()
{
    return frontIndex == -1;
}

int main()
{
    CircularQueue queue(3);
    queue.push(1);
    queue.push(2);
    queue.push(3);
    //queue.print();
    //cout << queue.peek() << endl;
    queue.push(4);
    queue.push(5);
    queue.print();
    queue.push(6);
    queue.push(7);
    queue.print();
    cout << queue.peek() << endl;
    queue.pop();
    cout << queue.peek() << endl;
    queue.pop();
    cout << queue.peek() << endl;
    return 0;
}