#from binaryTree import BinarySearchTree

class BinaryTreeOperations:
    def __init__(self):
        self.tree = None

    def find_min_recursive(self, root):
        if root is None:
            return -1
        if root.left is None:
            return root.data
        return self.find_min_recursive(root.left)

    def find_min(self):
        return self.find_min_recursive(self.tree.root)

    def find_height_recursive(self, root):
        if root is None:
            return -1

        result1 = self.find_height_recursive(root.left)
        result2 = self.find_height_recursive(root.right)
        return max(result1, result2)  + 1

    def find_height(self):
        return self.find_height_recursive(self.tree.root)
    
    def level_order(self):
        if self.tree.root == None:
            return
        queue = []
        queue.append(self.tree.root)
        while not queue == []:
            current = queue.pop(0)
            print(current.data)
            if current.left is not None:
                queue.append(current.left)
            if current.right is not None:
                queue.append(current.right)
    
    def preorder_traversal(self, root):
        if root is None:
            return
        print(root.data)
        self.preorder_traversal(root.left)
        self.preorder_traversal(root.right)