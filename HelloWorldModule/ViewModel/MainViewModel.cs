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

        public ICommand LoadCustomersCommand { get; private set; }
        public ICommand AddNewCustomControlCommand{ get; private set; }


        private ObservableCollection<MSAFocusControlViewModel> _focusControlViewModelsCollection;
        public ObservableCollection<MSAFocusControlViewModel> FocusControlViewModelCollection
        {
            get { return this._focusControlViewModelsCollection; }
            set { SetProperty(ref this._focusControlViewModelsCollection, value); }
        }


        public MainViewModel()
        {
            FocusControlViewModelCollection = new ObservableCollection<MSAFocusControlViewModel>();
            //FocusControlViewModelCollection.Add(new MSAFocusControlViewModel { Id = "From Parent 1" });
            //FocusControlViewModelCollection.Add(new MSAFocusControlViewModel { Id = "From Parent 2" });
            //FocusControlViewModelCollection.Add(new MSAFocusControlViewModel { Id = "From Parent 3" });

            Customers = new ObservableCollection<Customer>();

            CustomerView = new CollectionView(Customers);
            SearchText = string.Empty;
            this.LoadCustomersCommand = new DelegateCommand<object>(
                                   this.OnLoadCustomersCommand, this.CanLoadCustomersCommand);

            this.AddNewCustomControlCommand = new DelegateCommand<object>(
                                   this.OnLoadAddNewCustomControlCommand, this.CanAddNewCustomControlCommand);
        }

        private void OnLoadAddNewCustomControlCommand(object obj)
        {
            FocusControlViewModelCollection.Add(new MSAFocusControlViewModel { Id = "From Parent 1" });
        }

        private bool CanAddNewCustomControlCommand(object arg)
        {
            return true;
        }

        private bool CanLoadCustomersCommand(object arg)
        {
            return true;
        }

        private void OnLoadCustomersCommand(object obj)
        {
            //Customers = new ObservableCollection<Customer>(customerService.GetAllCustomer());
            var customers = customerService.GetAllCustomer();
            CustomerView = CollectionViewSource.GetDefaultView(customers);

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
