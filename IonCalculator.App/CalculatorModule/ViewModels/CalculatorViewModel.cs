using System;
using System.Text.RegularExpressions;
using System.Windows;
using CalculatorModule.Helper;
using Prism.Commands;
using Prism.Mvvm;

namespace CalculatorModule.ViewModels
{
    public class CalculatorViewModel : BindableBase
    {
        private CalculatorStackHelper _stackHelper;
        private string _displayText;
        public DelegateCommand<string> OnButtonPressed { get; set; }
        private bool _clearDisplay = false;
        private string _currentOperator;


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

        private void OnPressed(string input)
        {

            if (_clearDisplay)
            {
                DisplayText = String.Empty;
                _clearDisplay = false;
            }
            
            if (input == "Reset")
            {
                _stackHelper.ClearStack();
            }

            if (string.IsNullOrWhiteSpace(DisplayText) == false)
            {
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
    }
}
