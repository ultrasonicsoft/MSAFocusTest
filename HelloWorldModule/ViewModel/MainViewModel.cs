using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using MSAFocusModule.Repository;
using MSAFocusModule.Utils;

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

        private string _parentMessageText;

        public string ParentMessageText
        {
            get { return this._parentMessageText; }
            set
            {
                SetProperty(ref this._parentMessageText, value);
            }
        }

        private string _uniqueId;

        public string UniqueId
        {
            get { return this._uniqueId; }
            set
            {
                SetProperty(ref this._uniqueId, value);
            }
        }

        private ICollectionView _customerView;

        public ICollectionView CustomerView
        {
            get { return this._customerView; }
            set { SetProperty(ref this._customerView, value); }
        }

        public ICommand LoadCustomersCommand { get; private set; }
        public ICommand AddNewCustomControlCommand { get; private set; }
        public ICommand SetChildrenMessageTextCommand { get; private set; }

        public ICommand SetParentMessageTextCommand { get; private set; }

        public ICommand AddNewRowCommand { get; private set; }
        public ICommand DeleteRowCommand { get; private set; }

        private int _uniqueCustomControlId = 0;
        private ObservableCollection<MSAFocusControlViewModel> _focusControlViewModelsCollection;
        public ObservableCollection<MSAFocusControlViewModel> FocusControlViewModelCollection
        {
            get { return this._focusControlViewModelsCollection; }
            set { SetProperty(ref this._focusControlViewModelsCollection, value); }
        }


        public MainViewModel(ICustomerService _customerService)
        {
            this._customerService = _customerService;
            FocusControlViewModelCollection = new ObservableCollection<MSAFocusControlViewModel>();
            Customers = new ObservableCollection<Customer>();
            CustomerView = new CollectionView(Customers);
            SearchText = string.Empty;

            this.LoadCustomersCommand = new DelegateCommand<object>(
                                   this.OnLoadCustomersCommand, _ => true);

            this.AddNewCustomControlCommand = new DelegateCommand<object>(
                                   this.OnLoadAddNewCustomControlCommand, _ => true);

            this.SetChildrenMessageTextCommand = new DelegateCommand<object>(
                                               this.OnLoadSetChildrenMessageTextCommand, _ => FocusControlViewModelCollection.Count > 0);

            this.SetParentMessageTextCommand = new DelegateCommand<object>(
                                               this.OnLoadSetParentMessageTextCommand, _ => FocusControlViewModelCollection.Count > 0);

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

        private void OnLoadSetParentMessageTextCommand(object obj)
        {
            var senderCustomControlViewModel = obj as MSAFocusControlViewModel;
            if (senderCustomControlViewModel != null)
            {
                ParentMessageText = senderCustomControlViewModel.CustomMessage;
            }
        }

        private void OnLoadSetChildrenMessageTextCommand(object obj)
        {
            if (!string.IsNullOrEmpty(UniqueId))
            {
                var msaFocusControlViewModel =
                    FocusControlViewModelCollection.FirstOrDefault(
                        customControl => customControl.Id.Equals(UniqueId));
                if (msaFocusControlViewModel != null)
                {
                    msaFocusControlViewModel.CustomMessage = ParentMessageText;
                }
            }
            else
            {
                foreach (var msaFocusControlViewModel in FocusControlViewModelCollection)
                {
                    msaFocusControlViewModel.CustomMessage = ParentMessageText;
                }
            }
        }

        private void OnLoadAddNewCustomControlCommand(object obj)
        {
            _uniqueCustomControlId++;
            MSAFocusControlViewModel newControlViewModel = new MSAFocusControlViewModel
            {
                Id = _uniqueCustomControlId.ToString(),
                CustomMessage = string.Empty
            };
            FocusControlViewModelCollection.Add(newControlViewModel);
            ((DelegateCommand<object>)SetChildrenMessageTextCommand).RaiseCanExecuteChanged();
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
