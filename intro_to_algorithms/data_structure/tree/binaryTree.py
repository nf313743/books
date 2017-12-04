from binaryTreeOperations import BinaryTreeOperations

class Node:
    def __init__(self):
        self.left = None
        self.right = None
        self.data = 0

class BinarySearchTree:
    def __init__(self):
        self.root = None
        self.operations = BinaryTreeOperations()
        self.operations.tree = self

    def search_recursive(self, root, data):
        if root is None:
            return False
        if data == root.data:
            return True
        elif data < root.data:
            return self.search_recursive(root.left, data)
        return self.search_recursive(root.right, data)

    def search(self, data):
        return self.search_recursive(self.root, data)

    def insert_recursive(self, root, data):
        if root is None:
            new_node = Node()
            new_node.data = data
            return new_node

        if  data <= root.data:
            root.left = self.insert_recursive(root.left, data)
        elif data > root.data:
            root.right = self.insert_recursive(root.right, data)
        return root

    def insert(self, data):
        self.root = self.insert_recursive(self.root, data)

    def level_order(self):
        self.operations.level_order()

    def preorder_traversal(self):
        self.operations.preorder_traversal(self.root)
    
    def find_min_node_recursive(self, root):
        if root is None:
            return None
        if root.left is None:
            return root
        return self.find_min_node_recursive(root.left)

    def find_min_node(self, root):
        return self.find_min_node_recursive(root)

    def delete(self, root, data):
        if root is None:
            return root
        elif data < root.data:
            root.left = self.delete(root.left, data)
        elif data > root.data:
            root.right = self.delete(root.right, data)
        else:
            if root.left is None and root.right is None:
                # Case1 no children
                root = None
            elif root.left is None:
                # case2 1 child
                # Just make current node the right node.
                root = root.right
            else:
                # case 3 2 children
                min_node = self.find_min_node(root.right)
                root.data = min_node.data
                root.right = self.delete(root.right, min_node.data)
        return root

if __name__ == '__main__':
    tree = BinarySearchTree()
    tree.insert(3)
    tree.insert(2)
    #tree.find_height()
    tree.insert(10)
    tree.insert(20)
    tree.insert(30)
    tree.insert(9)
    tree.insert(16)
    tree.insert(17)
    result = tree.search(10)
    print(result)
    result = tree.search(30)
    print(result)
    result = tree.search(16)
    print(result)
    result = tree.search(5)
    print(result)
    result = tree.search(345)
    print(result)

    tree = BinarySearchTree()
    tree.insert(10)
    tree.insert(2)
    tree.insert(3)
    tree.insert(20)
    tree.insert(30)
    tree.insert(22)
    tree.insert(32)
    tree.insert(31)
    #tree.level_order()
    print()
    tree.preorder_traversal()
    print()
    tree.delete(tree.root, 30)
    tree.preorder_traversal()
   # print("Min value is: " + str(tree.find_min()))
   # print("Max height = " + str(tree.find_height()))
