using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Polish_Notation
{
    public class RPN
    {
        public double Calculate(string expression)
        {
            List<double> numbers = new List<double>();
            List<string> operations = new List<string>();
            bool isOpeningBracket = false;

            for(int i=0;i<expression.Length;i++)
            {
                string symbol= expression[i].ToString();

                if(symbol=="(")
                {
                    isOpeningBracket = true;
                }

                if(i%2==0&&!isOpeningBracket||isOpeningBracket&& i % 2 != 0)
                {
                    try
                    {
                        numbers.Add(Convert.ToDouble(symbol));
                        continue;
                    }
                    catch
                    {
                        throw new Exception("Wrong expression");
                    }
                }

                else
                {
                    string currentOperation = symbol;

                    if (symbol != "/" && symbol != "(" && symbol != ")" && symbol != "-" &&
                        symbol != "+" && symbol != "*" && symbol != "^")
                    {
                        throw new Exception("Wrong expression");
                    }

                    else
                    {
                        if(operations.Count==0||Prioritization(operations.Last<string>(),symbol)==1)
                        {
                            operations.Add(symbol);
                        }
                        else
                        {
                            if (symbol != ")")
                            {
                                CalculateResultOfAnOperation(ref operations, ref numbers);
                                operations.Add(symbol);
                            }
                            else
                            {
                                while (operations.Last<string>() != "(")
                                {
                                     CalculateResultOfAnOperation(ref operations, ref numbers);
                                }
                                operations.RemoveAt(operations.Count - 1);
                                isOpeningBracket = false;
                            }

                        }
                    }
                }

            }

            while(numbers.Count!=1)
            {
                CalculateResultOfAnOperation(ref operations, ref numbers);
            }

                return numbers[0];
        }

        private int Prioritization(string lastOperation,string operation)
        {
                    if (((lastOperation == "-" || lastOperation == "+") &&
                        (operation == "/" || operation == "^" || operation == "*"))
                        || operation == "("|| lastOperation == "(")
                    {
                        return 1;
                    }
                    return 0;
        }
        private void CalculateResultOfAnOperation(ref List<string> operations,ref List<double> numbers)
        {
            double result = 0;
            double firstNumber = numbers[numbers.Count - 2];
            double secondNumber = numbers.Last<double>();

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

            numbers.RemoveRange(numbers.Count - 2, 2);
            numbers.Add(result);
            operations.RemoveAt(operations.Count - 1);
        }
    }
}
