using CalculatorMainShell.Views;
using Prism.Ioc;
using System.Windows;
using CalculatorModule;
using Prism.Modularity;

namespace CalculatorMainShell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<CalculatorModuleSetup>();
        }
    }
}
