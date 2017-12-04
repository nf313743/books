#include "node.cpp"
#include <iostream>

class MyList
{
    public:
        MyList();
  
        void insert(int data, int n);
        void deleteNode(int n);
        void reverseList();
        void print();
        void printRecursive();
        void sumRecursive();
        void reverseListRecursive();
    protected:
        Node* head;
        void print(Node* node);
        int sum(Node* node);
        void reverse(Node* node);
};

MyList::MyList()
{
    head = 0;

}

void MyList::reverseList()
{
    Node *currentNode = head;
    Node *prevNode;
    Node *nextNode;
    prevNode = 0;

    while(currentNode != 0)
    {
        nextNode = currentNode->next;
        currentNode->next = prevNode;
        prevNode = currentNode;
        currentNode = nextNode;
    }
    head = prevNode;
}

void MyList::reverseListRecursive()
{
    reverse(head);
}

void MyList::reverse(Node* node)
{
    if(node->next == 0)
    {
        head = node;
        return;
    }
    
    reverse(node->next);
    
    // Save node B into temp.
    Node* temp = node->next;

    // Node B now points to Node A
    temp->next = node;

    // Alternative
    //node->next->next = node;
    
    // Node A is now the end of the list
    node->next = 0;
}

void MyList::insert(int data, int n)
{
    Node* newNode = new Node();
    newNode->data = data;
    newNode->next = 0;

    if (n==1){
        newNode->next = head;
        head = newNode;
        return;
    }
    Node* tempNode = head;
    for(int i = 0; i < n-2; ++i){
        tempNode = tempNode->next;
    }
    newNode->next = tempNode->next;
    tempNode->next = newNode;
}

void MyList::deleteNode(int n)
{
    Node* temp1 = head;
    if (n == 1){
        head = temp1->next;
        delete temp1;
        return;
    }
    for(int i = 0; i < n-2; ++i)
    {
        temp1 = temp1->next;
    }
    Node* nNode = temp1->next;
    temp1->next = nNode->next;
    delete nNode;
}

void MyList::print()
{
    Node* currentNode = head;
    while(currentNode != 0)
    {
        std::cout << currentNode->data << " ";
        currentNode = currentNode->next;
    }
    std::cout << std::endl;
}

void MyList::printRecursive()
{
    print(head);
    std::cout << std::endl;
}

void MyList::print(Node* node)
{
    if (node == 0)
    {
        return;
    }
    std::cout << node->data << " ";
    print(node->next);
}

void MyList::sumRecursive()
{
    int result = sum(head);
    std::cout << "Sum: " << result << std::endl;
}

int MyList::sum(Node* node)
{
    if (node == 0)
    {
        return 0;
    }
    return node->data + sum(node->next);
}