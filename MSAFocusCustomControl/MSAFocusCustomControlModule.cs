using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using MSAFocusCustomControl.ViewModel;
using MSAFocusCustomControl.Views;

//using MSAFocusCustomControl.View;

namespace MSAFocusCustomControl
{
    public class MSAFocusCustomControlModule: IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;
        public IUnityContainer Container { get; private set; }

        public MSAFocusCustomControlModule(IUnityContainer container, IRegionViewRegistry _regionViewRegistry)
        {
            Container = container;
            this.regionViewRegistry = _regionViewRegistry;
        }

        public void Initialize()
        {
            Container.RegisterType<IViewModel, CustomUserControlRendererViewModel>();
            regionViewRegistry.RegisterViewWithRegion("MSAFocusUserControlRegion", typeof(CustomUserControlRendererView));
        }

       
    }
}
