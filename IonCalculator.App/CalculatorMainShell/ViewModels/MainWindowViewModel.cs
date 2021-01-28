using Prism.Mvvm;

namespace CalculatorMainShell.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Ion Calculator Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
