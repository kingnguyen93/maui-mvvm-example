using MauiMvvmExample.ViewModels;

namespace MauiMvvmExample.Views
{
    public partial class ItemDetailPage
    {
        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}