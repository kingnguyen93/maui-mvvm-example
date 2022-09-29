using MauiMvvmExample.ViewModels;

namespace MauiMvvmExample.Views
{
    public partial class ItemsPage
    {
        public ItemsPage(ItemsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}