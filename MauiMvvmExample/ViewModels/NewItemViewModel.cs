using MauiMvvmExample.Models;
using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiMvvmExample.Services;

namespace MauiMvvmExample.ViewModels
{
    public partial class NewItemViewModel : BaseViewModel
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private string text;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private string description;

        private readonly IDataStore<Item> dataStore;

        public NewItemViewModel(IDataStore<Item> dataStore)
        {
            this.dataStore = dataStore;
        }

        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(description);
        }

        [RelayCommand(CanExecute = nameof(ValidateSave))]
        private async void OnSave()
        {
            Item newItem = new()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description
            };

            await dataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await GoBackAsync();
        }

        [RelayCommand]
        private async Task OnCancel()
        {
            // This will pop the current page off the navigation stack
            await GoBackAsync();
        }
    }
}
