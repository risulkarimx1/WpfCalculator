using System.Linq;
using CalculatorModule.Helper;
using Prism.Commands;
using Prism.Mvvm;

namespace CalculatorModule.ViewModels
{
    public class CalculatorViewModel : BindableBase
    {
        private CalculatorStackHelper _stackHelper;
        private string _message;
        private string _displayText;
        public DelegateCommand<string> OnButtonPressed { get; set; }


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
            if (input != "=")
            {
                DisplayText += input;
                _stackHelper.AddToStack(input);
            }
        }

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
    }
}
