namespace MauiMvvmExample
{
    public class BasePage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is BaseViewModel vm)
            {
                vm.OnAppearingAsync();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (BindingContext is BaseViewModel vm)
            {
                vm.OnDisappearingAsync();
            }
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            if (BindingContext is BaseViewModel vm)
            {
                vm.OnNavigatedToAsync();
            }
        }

        protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
        {
            base.OnNavigatingFrom(args);

            if (BindingContext is BaseViewModel vm)
            {
                vm.OnNavigatingFromAsync();
            }
        }

        protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
        {
            base.OnNavigatedFrom(args);

            if (BindingContext is BaseViewModel vm)
            {
                vm.OnNavigatedFromAsync();
            }
        }
    }
}