'''
In normal algebra we use the infix notation like a+b*c. The corresponding postfix notation is abc*+. The algorithm for the conversion is as follows :

* Scan the Infix string from left to right.
* Initialise an empty stack.
* If the scannned character is an operand, add it to the Postfix string. If the scanned character is an operator and if the stack is empty Push the character to stack.
    > If the scanned character is an Operand and the stack is not empty, compare the precedence of the character with the element on top of the stack (topStack). 
    If topStack has higher precedence over the scanned character Pop the stack else Push the scanned character to stack. Repeat this step as long as stack is not empty and topStack has precedence over the character.
  Repeat this step till all the characters are scanned.
* (After all characters are scanned, we have to add any character that the stack may have to the Postfix string.) 
    If stack is not empty add topStack to Postfix string and Pop the stack. Repeat this step as long as stack is not empty.
* Return the Postfix string. 
'''
# a * b + c * d - e
# -> {(a*b)+(c*d)}-e
#-> {(ab*) + (cd*)}-e
#-> {(ab*)(cd*)+}-e
#-> {(ab*)(cd*)+}e-
#-> ab*cd*+e-


class InfixToPostfix:

    def is_operand(self, char):
        operandList = ("*", "+", "-", "/")
        if char in operandList:
            return True
        return False

    def operator_val(self, char):
        if char == "^":
            return 8
        if char == "*":
            return 7
        if char == "/":
            return 6
        if char == "+":
            return 5
        if char == "-":
            return 4
        return 0

    def has_lower_precedence(self, operator, stack_operator):
        # If the operator is greater than the one in the stack
        # pop the stack until it finds one less than itself.
        if self.operator_val(operator) > self.operator_val(stack_operator):
            return False
        return True

    def push_to_stack(self, stack, operator, postFixExp):
        if not stack:
            stack.append(operator)
        else:
            while(stack and self.has_lower_precedence(operator, stack[-1])):
                val = stack.pop()
                postFixExp.append(val)
            stack.append(operator)

    def convert_to_postfix(self, expression):
        stack = []
        postFixExp = []
        for i in range(0, len(expression)):
            char = expression[i]
            if self.is_operand(char):
                self.push_to_stack(stack, char, postFixExp)
            else:
                postFixExp.append(char)
        while len(stack) > 0:
            postFixExp.append(stack.pop())
        return postFixExp


if __name__ == "__main__":
    infixToPostfix = InfixToPostfix()
    infixStr = "a*b+c*d-e"
    postFix = infixToPostfix.convert_to_postfix(infixStr)
    print(postFix)
