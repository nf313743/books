from binaryTree import BinarySearchTree



def is_binary_search_tree(root):
    return is_binary_search_tree_recursive(root, float("-inf"), float("inf"))

def is_binary_search_tree_recursive(root, min_val, max_val):
    if root is None:
        return True
    p1 = is_binary_search_tree_recursive(root.left, min_val, root.data)
    p2 = is_binary_search_tree_recursive(root.right, root.data, max_val)

    if p1 and p2 and root.data > min_val and root.data < max_val:
        return True
    return False

tree = BinarySearchTree()
tree.insert(12)
tree.insert(5)
tree.insert (20)
print(is_binary_search_tree(tree.root))