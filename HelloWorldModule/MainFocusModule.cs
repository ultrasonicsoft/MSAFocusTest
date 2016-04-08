using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace MainFocusModule
{
    public class MainFocusModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        public MainFocusModule(IRegionViewRegistry registry)
        {
            this.regionViewRegistry = registry;   
        }

        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("MainRegion", typeof(Views.MainView));
        }
    }
}
