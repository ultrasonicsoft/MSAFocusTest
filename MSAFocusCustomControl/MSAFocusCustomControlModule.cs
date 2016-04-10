using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
//using MSAFocusCustomControl.View;

namespace MSAFocusCustomControl
{
    public class MSAFocusCustomControlModule: IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        public MSAFocusCustomControlModule(IRegionViewRegistry _regionViewRegistry)
        {
            this.regionViewRegistry = _regionViewRegistry;
        }

        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("MSAFocusUserControlRegion", typeof(View.MSAFocusCustomControl));
        }

       
    }
}
