using CommunityToolkit.Mvvm.Input;
using MauiMvvmExample.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiMvvmExample.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
        }

        [RelayCommand]
        async Task LoginAsync()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
        }
    }
}
