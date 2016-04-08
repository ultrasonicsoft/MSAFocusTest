// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Controls;
using HelloWorldModule.ViewModel;

namespace MainFocusModule.Views
{
    /// <summary>
    /// Interaction logic for HelloWorldView.xaml
    /// </summary>
    public partial class MainView
    {
        public MainView(IViewModel _viewModel)
        {
            InitializeComponent();
            this.DataContext = _viewModel;
        }
    }
}
