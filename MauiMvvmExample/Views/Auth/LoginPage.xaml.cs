using MauiMvvmExample.ViewModels;

namespace MauiMvvmExample.Views
{
    public partial class LoginPage
    {
        public LoginPage(LoginViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}