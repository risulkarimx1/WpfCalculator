using System;
using System.Threading.Tasks;
using System.Windows;

namespace CalculatorModule.Helper
{
    public static class FibonacciHelper
    {
        public static async Task<string> GetFibonacci(string number)
        {
            // TODO: Should use Progress <int> here
            
            await Task.Delay(TimeSpan.FromMilliseconds(500));

            double value;
            double.TryParse(number, out value);

            UInt64 n = (UInt64) value;

            int firstnumber = 0, secondnumber = 1, result = 0;

            if (n == 0) return 0.ToString(); //To return the first Fibonacci number   
            if (n == 1) return 1.ToString(); //To return the second Fibonacci number   


            for (UInt64 i = 2; i <= n; i++)
            {
                result = firstnumber + secondnumber;
                firstnumber = secondnumber;
                secondnumber = result;
            }

            if (result < 0)
            {
                return string.Empty;
            }
            
            return result.ToString();
        }
        
    }
}
