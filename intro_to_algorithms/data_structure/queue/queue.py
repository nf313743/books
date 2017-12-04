class Node:
    def __init__(self):
        self.data = 0
        self.nodeBehind = None
      

class MyQueue:

    def __init__(self):
        self.front = None
        self.back = None

    def enqueue(self, data):
        newNode = Node()
        newNode.data = data
        if self.front is None:
            self.front = newNode
            self.back = newNode
            newNode.nodeBehind = None
            return
        self.back.nodeBehind = newNode
        self.back = newNode

    def dequeue(self):
        if self.front is None:
            return None
        poppedNode = self.front
        self.front = self.front.nodeBehind
        return poppedNode

    def reverse_recursive(self, node):
        if node is None:
            return
        if node.nodeBehind is None:
            self.front = node
            return
        self.reverse_recursive(node.nodeBehind)
        tempNode = node.nodeBehind
        tempNode.nodeBehind = node
        node.nodeBehind = None
        self.back = node

    def reverse(self):
        self.reverse_recursive(self.front)


queue = MyQueue()
queue.enqueue(1)
queue.enqueue(5)
queue.enqueue(7)
queue.enqueue(3)
print("Front = " + str(queue.front.data))
print("Back = " + str(queue.back.data))
item = queue.dequeue()
while(item is not None):
    print(item.data, end=" ")
    item = queue.dequeue()
print()


queue.enqueue(1)
queue.enqueue(5)
queue.enqueue(7)
queue.enqueue(3)
queue.reverse()
print("Front = " + str(queue.front.data))
print("Back = " + str(queue.back.data))
item = queue.dequeue()
while(item is not None):
    print(item.data, end=" ")
    item = queue.dequeue()
print()


        
        

            

    

    
