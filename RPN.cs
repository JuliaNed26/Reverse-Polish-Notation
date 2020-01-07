using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Polish_Notation
{
    public class RPN
    {
        private readonly Dictionary<char,int> _allOperations;

        public RPN()
        {
            _allOperations= new Dictionary<char, int>
                {{'/', 1}, {'-', 0}, {'+', 0}, {'*', 1}, {'^', 2}, {'(', -1}, {')', -1}}; ;
        }

        public double PolishExpression(string expression)
        {


            string polishExpression = "";
            string operationsQueue = "";
            string number = "";

            for (int i = 0; i < expression.Length; i++)
            {
                char symbol = expression[i];

                if (_allOperations.ContainsKey(symbol)) //if symbol is operation
                {
                    if (number != "") //add number to polish expression
                    {
                        polishExpression += number + " ";
                        number = "";
                    }

                    else if (symbol != '(' && (i != 0 && expression[i - 1] != ')')) //operation can't stay before number
                    {
                        throw new Exception("Wrong expression");
                    }

                    if (operationsQueue == "" || _allOperations[operationsQueue.Last()] < _allOperations[symbol] || symbol == '(') //add operation to the queue of operations
                    {
                        operationsQueue += symbol;
                    }

                    else if (symbol != ')') //push last operation into polish expression
                    {
                        polishExpression += operationsQueue.Last() + " ";
                        operationsQueue = operationsQueue.Remove(operationsQueue.Length - 1) + symbol;
                    }

                    else//push only operations in brackets
                    {
                        string forPushing = operationsQueue.Remove(0, operationsQueue.IndexOf('(') + 1);
                        operationsQueue = operationsQueue.Remove(operationsQueue.IndexOf('('));

                        for (int k = forPushing.Length - 1; k >= 0; k--) //push operations in reverse order
                        {
                            polishExpression += forPushing[k] + " ";
                        }
                    }
                }

                else //create number
                {
                    number += symbol;
                }

                if (i == expression.Length - 1)
                {
                    polishExpression += number + " ";

                    for (int k = operationsQueue.Length - 1; k >= 0; k--)
                    {
                        polishExpression += operationsQueue[k] + " ";
                    }
                }
            }


            return polishExpression.Remove(polishExpression.Length - 1);
        }


        public double Calculate(string expression)
        {
            string number = "";
            List<double> numbers = new List<double>();

            foreach (char symbol in expression)
            {
                if (symbol == ' ' && number != "")
                {
                    numbers.Add(Convert.ToDouble(number));
                    number = "";
                }

                if (symbol != ' ')
                {
                    if (!_allOperations.ContainsKey(symbol))
                    {
                        number += symbol;
                    }
                    else
                    {
                        double result =
                            CalculateResultOfAnOperation(symbol, numbers[numbers.Count - 2],
                                numbers[numbers.Count - 1]);
                        numbers.RemoveRange(numbers.Count - 2, 2);
                        numbers.Add(result);
                    }
                }
            }

            return numbers[0];
        }

        private double CalculateResultOfAnOperation(char operation,double firsNumber,double secondNumber)
        {
            double result = 0;

            switch (operations.Last<string>())
            {
                case '-':
                    result = firstNumber - secondNumber;
                    break;

                case '+':
                    result = firstNumber + secondNumber;
                    break;

                case '/':
                    result = firstNumber / secondNumber;
                    break;

                case '*':
                    result = firstNumber * secondNumber;
                    break;

                case '^':
                    result = Math.Pow(firstNumber,secondNumber);
                    break;
            }

            return result;
        }
    }
}
