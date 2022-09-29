using MauiMvvmExample.Models;
using MauiMvvmExample.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using MauiMvvmExample.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiMvvmExample.Extensions;

namespace MauiMvvmExample.ViewModels
{
    public partial class ItemsViewModel : BaseViewModel
    {
        private readonly IDataStore<Item> dataStore;

        [ObservableProperty]
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; } = new();

        public ItemsViewModel(IDataStore<Item> dataStore)
        {
            this.dataStore = dataStore;

            Title = "Browse";
        }

        public override Task OnNavigatedToAsync()
        {
            return LoadItemsAsync();
        }

        [RelayCommand]
        async Task LoadItemsAsync()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await dataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task AddItemAsync()
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        [RelayCommand]
        async Task OnItemTapped(Item item)
        {
            if (item == null)
                return;

            SelectedItem = item;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}