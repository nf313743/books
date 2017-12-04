import math

def f1(microseconds):
    n = 0
    result = 0
    while(result < microseconds):
        n = n + 1
        result = math.log2(n)
    return n

result = f1(1 * 60 * math.pow(10, -6))
print(result)
