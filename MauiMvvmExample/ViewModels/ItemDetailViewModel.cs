using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MauiMvvmExample.Models;
using MauiMvvmExample.Services;

namespace MauiMvvmExample.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class ItemDetailViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string id;

        [ObservableProperty]
        private string text;

        [ObservableProperty]
        private string description;

        private readonly IDataStore<Item> dataStore;

        public ItemDetailViewModel(IDataStore<Item> dataStore)
        {
            this.dataStore = dataStore;
        }

        private string itemId;
        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                _ = LoadItemAsync(value);
            }
        }

        public async Task LoadItemAsync(string itemId)
        {
            try
            {
                var item = await dataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
