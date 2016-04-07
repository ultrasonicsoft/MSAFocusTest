using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HelloWorldModule.Repository;
using HelloWorldModule.Utils;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace HelloWorldModule.ViewModel
{
    public class MainViewModel  : BindableBase
    {
        private ICustomerService customerService = new CustomerService();

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get { return this._customers; }
            set { SetProperty(ref this._customers, value); }
        }

        private string _test;
        public string Test
        {
            get { return this._test; }
            set { SetProperty(ref this._test, value); }
        }

        //public string Test { get; private set; }
        public ICommand LoadCustomersCommand { get; private set; }
        public MainViewModel()
        {
            Test = "Balram";
            Customers = new ObservableCollection<Customer>();
            this.LoadCustomersCommand = new DelegateCommand<object>(
                                   this.OnLoadCustomersCommand, this.CanLoadCustomersCommand);

        }

        private bool CanLoadCustomersCommand(object arg)
        {
            return true;
        }

        private void OnLoadCustomersCommand(object obj)
        {
            Test = "Sujeet";
            Customers = new ObservableCollection<Customer>(customerService.GetAllCustomer());
        }
    }
}
