
def is_closing(c):
    closing = ["}", "]", ")"]
    if c in closing:
        return True
    return False

def is_matching(a, b):
    if a == "{" and b == "}":
        return True
    if a == "[" and b == "]":
        return True
    if a == "(" and b == ")":
        return True
    return False


def validation():
    stack = []
    for i in range(0, len(expression)):
        if is_closing(expression[i]):
            if not stack:
                return False, stack
            c = stack.pop()
            if not is_matching(c, expression[i]):
                return False, stack
        else:
            stack.append(expression[i])
        i+=1
    if len(stack) > 0:
        return False, stack

    return True, stack


while(True):
    print("Enter parentheses: ")
    expression = input().replace(" ", "")
    result, stack = validation()
    if not result:
        print("Invalid sequence3")
        for c in stack:
            print(c)
    else:
        print("Sequence valid")
