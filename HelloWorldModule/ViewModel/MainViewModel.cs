using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using MSAFocusModule.Model;
using MSAFocusModule.Repository;

namespace MSAFocusModule.ViewModel
{
    public class MainViewModel : BindableBase, IViewModel
    {
        private readonly ICustomerService _customerService;

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

        public ICommand LoadCustomersCommand { get; private set; }

        public ICommand AddNewRowCommand { get; private set; }
        public ICommand DeleteRowCommand { get; private set; }

        public MainViewModel(ICustomerService _customerService)
        {
            this._customerService = _customerService;
            Customers = new ObservableCollection<Customer>();
            CustomerView = new CollectionView(Customers);
            SearchText = string.Empty;

            this.LoadCustomersCommand = new DelegateCommand<object>(
                                   this.OnLoadCustomersCommand, _ => true);

            this.AddNewRowCommand= new DelegateCommand<object>(
                                                           this.OnLoadAddNewRowCommand, _ => true);

            this.DeleteRowCommand = new DelegateCommand<object>(
                                                          this.OnLoadDeleteRowCommand, _ => true);

        }

        private void OnLoadDeleteRowCommand(object obj)
        {
            var selectedCustomer = obj as Customer;
            if (selectedCustomer == null)
            {
                return;
            }
            Customers.Remove(selectedCustomer);
        }

        private void OnLoadAddNewRowCommand(object obj)
        {
            //TODO: Add new row logic here
        }

        private void OnLoadCustomersCommand(object obj)
        {
            Customers = new ObservableCollection<Customer>(_customerService.GetAllCustomer());
            CustomerView = CollectionViewSource.GetDefaultView(Customers);

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
