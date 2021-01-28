using CalculatorModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace CalculatorModule
{
    public class CalculatorModuleSetup : IModule
    {
        private readonly IRegionManager _regionManager;


        public CalculatorModuleSetup(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(CalculatorView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}