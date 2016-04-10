using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;


namespace MSAFocusCustomControl.ViewModel
{
    public class CustomUserControlRendererViewModel : BindableBase, IViewModel
    {
        private string _parentMessageText;

        public string ParentMessageText
        {
            get { return this._parentMessageText; }
            set
            {
                SetProperty(ref this._parentMessageText, value);
                ((DelegateCommand<object>)SetChildrenMessageTextCommand).RaiseCanExecuteChanged();
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

        public ICommand AddNewCustomControlCommand { get; private set; }
        public ICommand SetChildrenMessageTextCommand { get; private set; }

        public ICommand SetParentMessageTextCommand { get; private set; }

        private int _uniqueCustomControlId = 0;
        private ObservableCollection<MSAFocusControlViewModel> _focusControlViewModelsCollection;
        public ObservableCollection<MSAFocusControlViewModel> FocusControlViewModelCollection
        {
            get { return this._focusControlViewModelsCollection; }
            set { SetProperty(ref this._focusControlViewModelsCollection, value); }
        }


        public CustomUserControlRendererViewModel()
        {
            FocusControlViewModelCollection = new ObservableCollection<MSAFocusControlViewModel>();
         
            this.AddNewCustomControlCommand = new DelegateCommand<object>(
                                   this.OnLoadAddNewCustomControlCommand, _ => true);

            this.SetChildrenMessageTextCommand = new DelegateCommand<object>(
                                               this.OnLoadSetChildrenMessageTextCommand, _ => FocusControlViewModelCollection.Count > 0 && ! string.IsNullOrEmpty(ParentMessageText));

            this.SetParentMessageTextCommand = new DelegateCommand<object>(
                                               this.OnLoadSetParentMessageTextCommand, _ => FocusControlViewModelCollection.Count > 0);
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

    }
}
