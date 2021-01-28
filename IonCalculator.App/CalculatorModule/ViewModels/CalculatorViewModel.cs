using Prism.Mvvm;

namespace CalculatorModule.ViewModels
{
    public class CalculatorViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public CalculatorViewModel()
        {
            Message = "View A from your Prism Module c";
        }
    }
}
