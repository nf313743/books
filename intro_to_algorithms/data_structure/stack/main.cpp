#include <iostream>
#include "myStack.cpp"
int main()
{
    MyStack stack;
    stack.push(1);
    stack.push(3);
    stack.push(7);
    stack.push(11);

    while(!stack.isEmpty())
    {
        std::cout << stack.pop() << " ";
    }
    std::cout << std::endl;

    return 0;
}