
class PostfixEvaluation:
    #def __init__(self):
    def is_operator(self, char):
        charList = ("*", "+", "-", "/")
        if char in charList:
            return True
        return False
    
    def calculate(self, operator, op1, op2):
        num1 = int(op1) 
        num2 = int(op2) 
        if operator == "*":
            return num1 * num2
        elif operator == "/":
            return num1 / num2
        elif operator == "+":
            return num1 + num2
        return num1 - num2
    
    def evaluate(self, expression):
        stack = []
        for i in range(0, len(expression)):
            char = expression[i]
            if not self.is_operator(char):
                stack.append(char)
            else:
                op2 = stack.pop()
                op1 = stack.pop()
                result = self.calculate(char, op1, op2)
                stack.append(result)
        return stack.pop()


if __name__ == '__main__':
    pfe = PostfixEvaluation()
    print("Input values:" )
    #expression = input().replace(" ", "")
    #expression = "23*54*+9-" = 17
    expression = "82/52**2*54*+" # 100
    result = pfe.evaluate(expression)
    print(result)


