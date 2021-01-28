using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CalculatorModule.Helper;
using Microsoft.VisualBasic;
using Prism.Commands;
using Prism.Mvvm;
using static System.String;

namespace CalculatorModule.ViewModels
{
    public class CalculatorViewModel : BindableBase
    {
        private CalculatorStackHelper _stackHelper;
        private string _displayText;
        public DelegateCommand<string> OnButtonPressed { get; set; }
        private bool _clearDisplay = false;
        private string _currentOperator;
        private int _progressValue;

        public int ProgressValue
        {
            get => _progressValue;
            set => SetProperty(ref _progressValue , value);
        }

        public string CurrentOperator
        {
            get => _currentOperator;
            set => SetProperty(ref _currentOperator, value);
        }

        public CalculatorViewModel()
        {
            OnButtonPressed = new DelegateCommand<string>(OnPressed);
            _stackHelper = new CalculatorStackHelper();
        }

        public string DisplayText
        {
            get => _displayText;
            set => SetProperty(ref _displayText, value);
        }

        private async void OnPressed(string input)
        {
            if (_clearDisplay)
            {
                DisplayText = Empty;
                _clearDisplay = false;
            }
            
            if (input == "Reset")
            {
                ResetDisplay();
            }

            if (IsNullOrWhiteSpace(DisplayText) == false)
            {
                if (input == "Fib")
                {
                    ProgressValue = 0;
                    var progressTask = ProgressFillTask();
                    var fibTask = FibonacciHelper.GetFibonacci(DisplayText);
                    await Task.WhenAll(fibTask, progressTask);
                    DisplayText = fibTask.Result;
                    _stackHelper.ClearStack();
                    _clearDisplay = true;
                    return;
                }
                
                if (input == "+/-")
                {
                    var firstChar = DisplayText[0];
                    if (firstChar == '-')
                    {
                        DisplayText = DisplayText.Substring(1, DisplayText.Length - 1);
                    }
                    else
                    {
                        DisplayText = "-" + DisplayText;
                    }
                }
            }

            if (Regex.IsMatch(input, @"^\d+$") || input == ".")
            {
                DisplayText += input;
            }
            else if (_stackHelper.IsOperator(input))
            {
                CurrentOperator = input;
                _stackHelper.AddToStack(DisplayText);
                if (_stackHelper.CanProcess())
                {
                    DisplayText = _stackHelper.ProcessStack();
                    _stackHelper.AddToStack(input);
                    _clearDisplay = true;
                }
                else
                {
                    _stackHelper.AddToStack(DisplayText);
                    _stackHelper.AddToStack(input);
                    _clearDisplay = true;
                }
            }
            
            else if(input == "=")
            {
                // var processedData = _stackHelper.ProcessStack();
                // DisplayText = processedData;
                // _clearDisplay = true;
                // _stackHelper.ClearStack();
            }
        }

        private void ResetDisplay()
        {
            DisplayText = Empty;
            _stackHelper.ClearStack();
        }

        private async Task ProgressFillTask()
        {
            for (int i = 0; i < 500; i++)
            {
                ProgressValue += 10;
                await Task.Delay(1);
            }
        }
    }
}
