using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiMvvmExample.ViewModels;

namespace MauiMvvmExample
{
    [INotifyPropertyChanged]
    public partial class BaseViewModel : IQueryAttributable
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title = string.Empty;

        public bool IsNotBusy => !IsBusy;

        bool isFirstLoad = true;
        bool isInited;
        // Order: 1
        public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (isFirstLoad)
            {
                isFirstLoad = false;
                OnInitAsync(query);
                if (query.TryGetValue(nameof(ParameterKeys.Default), out object value))
                {
                    OnInitAsync(value);
                }
                isInited = true;
            }
            else
            {
                OnBackAsync(query);
                if (query.TryGetValue(nameof(ParameterKeys.Default), out object value))
                {
                    OnBackAsync(value);
                }
                if (query.TryGetValue(nameof(ParameterKeys.IsGoBack), out _))
                {
                    query.Clear();
                }
            }
        }

        public virtual Task OnInitAsync(IDictionary<string, object> query) => Task.CompletedTask;
        public virtual Task OnInitAsync(object value) => Task.CompletedTask;

        public virtual Task OnBackAsync(IDictionary<string, object> query) => Task.CompletedTask;
        public virtual Task OnBackAsync(object value) => Task.CompletedTask;

        // Order: 2
        public virtual Task OnAppearingAsync()
        {
            if (isFirstLoad)
                isFirstLoad = false;
            Debug.WriteLine($"{GetType().Name}.{nameof(OnAppearingAsync)}");
            return Task.CompletedTask;
        }

        // Order: 3
        public virtual Task OnNavigatedToAsync()
        {
            if (!isInited)
            {
                OnInitAsync(new Dictionary<string, object>());
                isInited = true;
            }
            Debug.WriteLine($"{GetType().Name}.{nameof(OnNavigatedToAsync)}");
            return Task.CompletedTask;
        }

        // Order: 4
        public virtual Task OnNavigatingFromAsync()
        {
            Debug.WriteLine($"{GetType().Name}.{nameof(OnNavigatingFromAsync)}");
            return Task.CompletedTask;
        }

        // Order: 5
        public virtual Task OnDisappearingAsync()
        {
            Debug.WriteLine($"{GetType().Name}.{nameof(OnDisappearingAsync)}");
            return Task.CompletedTask;
        }

        // Order: 6
        public virtual Task OnNavigatedFromAsync()
        {
            Debug.WriteLine($"{GetType().Name}.{nameof(OnNavigatedFromAsync)}");
            return Task.CompletedTask;
        }

        [RelayCommand]
        protected async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..", new Dictionary<string, object>()
            {
                { nameof(ParameterKeys.IsGoBack), true }
            });
        }

        protected async Task GoBackAsync(IDictionary<string, object> parameters)
        {
            parameters.Add(nameof(ParameterKeys.IsGoBack), true);
            await Shell.Current.GoToAsync("..", parameters);
        }

        protected async Task GoBackAsync(object value)
        {
            await Shell.Current.GoToAsync("..", new Dictionary<string, object>
            {
                { nameof(ParameterKeys.Default), value },
                { nameof(ParameterKeys.IsGoBack), true }
            });
        }
    }
}
