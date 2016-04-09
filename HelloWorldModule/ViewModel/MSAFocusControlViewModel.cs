using Microsoft.Practices.Prism.Mvvm;

namespace MSAFocusModule.ViewModel
{
    public class MSAFocusControlViewModel : BindableBase, IViewModel
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

    }
}
