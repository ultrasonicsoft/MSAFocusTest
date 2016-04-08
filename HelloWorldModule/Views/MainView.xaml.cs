using System.Windows.Controls;
using HelloWorldModule.ViewModel;

namespace MainFocusModule.Views
{
    public partial class MainView
    {
        public MainView(IViewModel _viewModel)
        {
            InitializeComponent();
            this.DataContext = _viewModel;
        }
    }
}
