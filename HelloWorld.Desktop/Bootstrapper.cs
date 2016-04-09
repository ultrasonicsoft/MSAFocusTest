// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Windows;
using MSAFocusModule.Repository;
using MSAFocusModule.Utils;
using MSAFocusModule.ViewModel;
using MainFocusModule.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.UnityExtensions;

namespace MSAFocusShell
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            this.Container.RegisterType<ICustomerService, CustomerService>();
            //this.Container.RegisterType<ICustomerService, CustomerServiceMock>();
            this.Container.RegisterType<IViewModel, MainViewModel>();
            this.Container.RegisterType<ICustomerRepository, CustomerRepository>();
            this.Container.RegisterType<MainView>();

            return this.Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }     

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(MainFocusModule.MainFocusModule));
        }

        
    }
  
}
