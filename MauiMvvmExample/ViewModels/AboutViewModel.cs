using CommunityToolkit.Mvvm.Input;

namespace MauiMvvmExample.ViewModels
{
    public partial class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
        }

        [RelayCommand]
        async Task OpenWebAsync()
        {
            await Browser.OpenAsync("https://aka.ms/xamarin-quickstart");
        }
    }
}