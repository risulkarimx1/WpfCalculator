using System.Collections.Generic;

namespace CalculatorModule.Helper
{
    public class CalculatorStackHelper
    {
        public Stack<string> CalculatorStack { get; }

        public CalculatorStackHelper()
        {
            CalculatorStack = new Stack<string>();
        }

        public void AddToStack(string input)
        {
            CalculatorStack.Push(input);
        }
    }
}