#include "myList.cpp"

int main()
{
    MyList myList;
    myList.insert(2,1);
    myList.insert(3,2);
    myList.insert(4,1);
    myList.insert(5,2);
    myList.printRecursive();
    //myList.sumRecursive();
    myList.reverseListRecursive();
    //myList.reverseList();
    myList.print();
    //myList.deleteNode(4);
    //myList.print();
    //myList.reverseList();
    //myList.print();
    return 0;
}