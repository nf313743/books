#include "node.cpp"

class MyStack
{
    public:
        MyStack();
        void push(int value);
        int pop();
        int peek();
        bool isEmpty();
    private:
    Node* top;
};

MyStack::MyStack()
{
    top = 0; 
}

void MyStack::push(int value)
{
    Node* newNode = new Node();
    newNode->data = value;
    newNode->next = top;
    top = newNode;
}

int MyStack::pop()
{
    if (top == 0)
        return 0;
    Node* tempNode = top;
    top = tempNode->next;
    return tempNode->data;
}

bool MyStack::isEmpty()
{
    return top == 0;
}