using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace MSAFocusShell
{
    public class ShellViewModel : BindableBase
    {
        public ICommand OkCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public ShellViewModel()
        {
            this.OkCommand = new DelegateCommand<object>(
                                  _ => Application.Current.Shutdown(), _ => true);

            this.CancelCommand = new DelegateCommand<object>(
                                 _ => Application.Current.Shutdown(), _ => true);
        }
    }
}
