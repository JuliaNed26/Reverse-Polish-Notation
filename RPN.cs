using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Polish_Notation
{
    public class RPN
    {
        private readonly List<string> _allOperations;
        private readonly List<string> _brackets;

        public RPN()
        {
            _allOperations==new List<string>(){"/","-","+","*","^"};
            _brackets = new List<String>() { "(", ")" };
        }

        public double Calculate(string expression)
        {
            List<double> numbers = new List<double>();
            List<string> operations = new List<string>();
            string previousSymbol="";

            for(int i=0;i<expression.Length;i++)
            {
                string symbol= expression[i].ToString();

                if(!_allOperations.Contains(symbol)&&!_brackets.Contains(symbol))
                {
                    try
                    {
                        if (!_allOperations.Contains(previousSymbol) && _brackets.Contains(previousSymbol) &&
                            previousSymbol != "")
                        {
                            symbol = previousSymbol + symbol;
                        }
                        numbers.Add(Convert.ToDouble(symbol));
                        continue;
                    }
                    catch
                    {
                        throw new Exception("Wrong expression");
                    }
                }//adding numbers

                else
                {
                    if (_allOperations.Contains(previousSymbol))
                    {
                        throw new Exception("Wrong expression");
                    }//if previous symbol is operation too

                    else
                    {
                        if(Prioritization(operations.Last<string>(),symbol)==1)
                        {
                            operations.Add(symbol);
                        }//adding operation,if it's preoritization==1

                        else
                        {
                            if (symbol != ")")
                            {
                                numbers.Add(CalculateResultOfAnOperation(operations.Last(),numbers[numbers.Count-2],numbers.Last()));
                                numbers.RemoveRange(numbers.Count - 3, 2);
                                operations.RemoveAt(operations.Count - 1);
                                operations.Add(symbol);
                            }//calculate operation

                            else
                            {
                                while (operations.Last<string>() != "(")
                                {
                                    numbers.Add(CalculateResultOfAnOperation(operations.Last(), numbers[numbers.Count - 2], numbers.Last()));
                                    numbers.RemoveRange(numbers.Count - 3, 2);
                                    operations.RemoveAt(operations.Count - 1);
                                }

                                operations.RemoveAt(operations.Count - 1);
                            }//calculate while operation!=(

                        }
                    }
                }

                previousSymbol = symbol;

            }//expression's symbol parse into operation or number

            while(numbers.Count!=1)
            {
                numbers.Add(CalculateResultOfAnOperation(operations.Last(), numbers[numbers.Count - 2], numbers.Last()));
                numbers.RemoveRange(numbers.Count - 3, 2);
                operations.RemoveAt(operations.Count - 1);
            }//if operations aren't ended, calculations

            return numbers[0];
        }

        private int Prioritization(string lastOperation="",string operation)
        {
                    if (((lastOperation == "-" || lastOperation == "+") &&
                        (operation == "/" || operation == "^" || operation == "*"))
                        || operation == "("|| lastOperation == "("||lastOperation=="")
                    {
                        return 1;
                    }
                    return 0;
        }

        private double CalculateResultOfAnOperation(string operation,double firsNumber,double secondNumber)
        {
            double result = 0;

            switch (operations.Last<string>())
            {
                case "-":
                    result = firstNumber - secondNumber;
                    break;

                case "+":
                    result = firstNumber + secondNumber;
                    break;

                case "/":
                    result = firstNumber / secondNumber;
                    break;

                case "*":
                    result = firstNumber * secondNumber;
                    break;

                case "^":
                    result = Math.Pow(firstNumber,secondNumber);
                    break;
            }

            return result;
        }
    }
}
