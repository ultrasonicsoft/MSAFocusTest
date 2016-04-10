using System.Windows.Controls;
using MSAFocusCustomControl.ViewModel;

namespace MSAFocusCustomControl.Views
{
    public partial class CustomUserControlRendererView
    {
        public CustomUserControlRendererView(IViewModel _viewModel)
        {
            InitializeComponent();
            this.DataContext = _viewModel;
        }
    }
}
