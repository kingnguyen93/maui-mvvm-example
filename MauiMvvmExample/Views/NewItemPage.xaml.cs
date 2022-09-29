using MauiMvvmExample.ViewModels;

namespace MauiMvvmExample.Views
{
    public partial class NewItemPage
    {
        public NewItemPage(NewItemViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}