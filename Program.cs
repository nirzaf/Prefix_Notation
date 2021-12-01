// See https://aka.ms/new-console-template for more information

using Prefix_Notation;

Console.WriteLine("Hello, World!");

var expression = "+ 10 x";

var variables = "{ x : 3}";

int result = Prefix.CalculateExpression(expression, variables);

Console.WriteLine(result);
