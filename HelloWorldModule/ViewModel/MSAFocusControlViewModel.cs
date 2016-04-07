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
    public class MSAFocusControlViewModel : BindableBase
    {
        private string _id;
        public string Id
        {
            get { return this._id; }
            set
            {
                SetProperty(ref this._id, value);
            }
        }

        private string _customMessage;
        public string CustomMessage
        {
            get { return this._customMessage; }
            set
            {
                SetProperty(ref this._customMessage, value);
            }
        }

        public MSAFocusControlViewModel()
        {
            Id = "This is custom control";

        }
    }
}
