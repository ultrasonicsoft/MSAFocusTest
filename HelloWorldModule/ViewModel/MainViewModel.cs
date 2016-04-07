using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using HelloWorldModule.Repository;
using HelloWorldModule.Utils;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace HelloWorldModule.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private ICustomerService customerService = new CustomerService();

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get { return this._customers; }
            set { SetProperty(ref this._customers, value); }
        }

        private string _searchText;

        public string SearchText
        {
            get { return this._searchText; }
            set
            {
                SetProperty(ref this._searchText, value);
                CustomerView.Refresh();
            }

        }

        private ICollectionView _customerView;

        public ICollectionView CustomerView
        {
            get { return this._customerView; }
            set { SetProperty(ref this._customerView, value); }
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
            Customers = new ObservableCollection<Customer>();

            CustomerView = new CollectionView(Customers);
            Test = "Balram";
            SearchText = string.Empty;
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
            //Customers = new ObservableCollection<Customer>(customerService.GetAllCustomer());
            var customers = customerService.GetAllCustomer();
            CustomerView= CollectionViewSource.GetDefaultView(customers);

            if (CustomerView != null)
            {
                CustomerView.Filter = TextFilter;
            }

        }

        public bool TextFilter(object o)
        {
            Customer customer = (o as Customer);
            if (customer == null)
                return false;

            if (customer.Name.Contains(SearchText))
                return true;
            else
                return false;
        }
    }
}
