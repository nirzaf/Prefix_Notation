using System.Collections;

namespace Prefix_Notation;

public static class Prefix
{
    public static int CalculateExpression(string expression, string variables)
    {
        // Write your code here
        int prefix = EvaluatePrefix(expression);


    }

    static bool IsOperand(char c)
    {
        // If the character is a digit
        // then it must be an operand
        return c >= 48 && c <= 57;
    }

    static bool IsDigit(char ch)
    {
        return ch >= 48 && ch <= 57;
    }

    static int EvaluatePrefix(string expression)
    {
        Stack stack = new();
      
        for (int j = expression.Length - 1; j >= 0; j--) {
            
            // if jth character is the delimiter ( which is
            // space in this case) then skip it
            if (expression[j] == ' ')
                continue;
      
            // Push operand to Stack
            // To convert expression[j] to digit subtract
            // '0' from expression[j].
            if (IsDigit(expression[j])) {
                
                // there may be more than one digits in a number
                int num = 0, i = j;
                while (j < expression.Length && IsDigit(expression[j]))
                    j--;
                j++;
      
                // from [j, i] expression contains a number
                for (int k = j; k <= i; k++)
                {
                    num = num * 10 + (int)(expression[k] - '0');
                }
      
                stack.Push(num);
            }
            else {
      
                // Operator encountered
                // Pop two elements from Stack
                int o1 = (int)stack.Peek();
                stack.Pop();
                int o2 = (int)stack.Peek();
                stack.Pop();
      
                // Use switch case to operate on o1
                // and o2 and perform o1 O o2.
                switch (expression[j]) {
                    case '+':
                        stack.Push(o1 + o2);
                        break;
                    case '-':
                        stack.Push(o1 - o2);
                        break;
                    case '*':
                        stack.Push(o1 * o2);
                        break;
                    case '/':
                        stack.Push(o1 / o2);
                        break;
                }
            }
        }
      
        return (int)stack.Peek();
    }

}