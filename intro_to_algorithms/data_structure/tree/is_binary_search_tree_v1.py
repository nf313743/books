from binaryTree import BinarySearchTree

def is_subtree_lesser(root, value):
    if root is None:
        return True
    p1 = is_subtree_lesser(root.left, value)
    p2 = is_subtree_lesser(root.right, value)
    if root.data <= value and p1 and p2:
        return True
    return False

def is_subtree_greater(root, value):
    if root is None:
        return True
    p1 = is_subtree_greater(root.left, value)
    p2 = is_subtree_greater(root.right, value)
    if root.data >= value and p1 and p2:
        return True
    return False

def is_binary_search_tree(root):
    if root is None:
        return True
    p1 = is_subtree_lesser(root.left, root.data)
    p2 = is_subtree_greater(root.right, root.data)
    p3 = is_binary_search_tree(root.left)
    p4 = is_binary_search_tree(root.right)

    if p1 and p2 and p3 and p4:
        return True
    return False

tree = BinarySearchTree()
tree.insert(2)
tree.insert(5)
tree.insert (20)
print(is_binary_search_tree(tree.root))