// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Windows;
using MSAFocusModule.Model;
using MSAFocusModule.ViewModel;
using MainFocusModule.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.UnityExtensions;
using MSAFocusCustomControl;
using MSAFocusModule.Repository;

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
            this.Container.RegisterType<ShellViewModel>();
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

            moduleCatalog.AddModule(typeof(MSAFocusCustomControlModule));
        }
    }
  
}
