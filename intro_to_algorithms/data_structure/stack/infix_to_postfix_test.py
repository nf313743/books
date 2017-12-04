import unittest
from infix_to_postfix import InfixToPostfix

class InfixToPostfixTest(unittest.TestCase):
    def setUp(self):
        self.infixToPostfix = InfixToPostfix()

    def test01(self):
        infixToPostfix = InfixToPostfix()
        infixStr = "a*b+c*d-e"
        postFix = infixToPostfix.convert_to_postfix(infixStr)
        self.assertEqual("ab*cd*+e-", postFix)

