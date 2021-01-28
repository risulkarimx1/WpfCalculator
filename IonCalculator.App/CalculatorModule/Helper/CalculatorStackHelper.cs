using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using Microsoft.VisualBasic.CompilerServices;

namespace CalculatorModule.Helper
{
    public class CalculatorStackHelper
    {
        public Stack<string> _calculatorStack;

        public CalculatorStackHelper()
        {
            _calculatorStack = new Stack<string>();
        }

        public bool CanProcess()
        {
            if (_calculatorStack.Contains("+") || _calculatorStack.Contains("-") || _calculatorStack.Contains("*") || _calculatorStack.Contains("/"))
            {
                return true;
            }

            return false;
        }

        public void AddToStack(string input)
        {
            if (IsOperator(input))
            {
                if(_calculatorStack.Count == 0) return;
                
                var stackPeek = _calculatorStack.Peek();
                if (input == stackPeek)
                {
                    return;
                }
            }

            _calculatorStack.Push(input);
            
            
        }

        public void ClearStack()
        {
            _calculatorStack.Clear();
        }

        public string ProcessStack()
        {
            var firstValue = _calculatorStack.Pop();
            var ope = _calculatorStack.Pop();
            var lastValue = _calculatorStack.Pop();
            _calculatorStack.Clear();
            // add last value

            double first;
            double last;
            double output = 0;

            Double.TryParse(firstValue, out first);
            Double.TryParse(lastValue, out last);
            
            
            if (ope == "+")
            {
                output = first + last;
                _calculatorStack.Push(output.ToString(CultureInfo.InvariantCulture));
            }
            if (ope == "-")
            {
                output = last - first;
                _calculatorStack.Push(output.ToString(CultureInfo.InvariantCulture));
            }
            
            if (ope == "*")
            {
                output = last * first;
                _calculatorStack.Push(output.ToString(CultureInfo.InvariantCulture));
            }

            if (ope == "/")
            {
                if (last == 0)
                {
                    _calculatorStack.Clear();
                    return string.Empty;
                }
                else
                {
                    output = last / first;
                    _calculatorStack.Push(output.ToString(CultureInfo.InvariantCulture));
                }
            }
            
            
            return output.ToString(CultureInfo.InvariantCulture);
            
        }

        public bool IsOperator(string input)
        {
            if (input == "+" || input == "-" || input == "/" || input == "*") return true;
            return false;
        }

        private void PrintStack()
        {
            Console.WriteLine("======================");
            foreach (var val in _calculatorStack)
            {
                MessageBox.Show(val);
            }
        }
    }
}