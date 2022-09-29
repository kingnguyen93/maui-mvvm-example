using MauiMvvmExample.Models;
using MauiMvvmExample.Services;
using MauiMvvmExample.ViewModels;
using MauiMvvmExample.Views;

namespace MauiMvvmExample;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .ConfigureEssentials(essentials =>
            {
                essentials.UseVersionTracking();
            })
            .RegisterServices()
            .RegisterPages();

        return builder.Build();
    }

    static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton(AppInfo.Current);
        builder.Services.AddSingleton(Preferences.Default);
        builder.Services.AddSingleton(MessagingCenter.Instance);

        builder.Services.AddSingleton<IDataStore<Item>, MockDataStore>();

        return builder;
    }

    static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
    {
        builder.Services.RegisterPage<LoginPage, LoginViewModel>();
        builder.Services.RegisterPage<ItemsPage, ItemsViewModel>();
        builder.Services.RegisterPage<ItemDetailPage, ItemDetailViewModel>();
        builder.Services.RegisterPage<NewItemPage, NewItemViewModel>();
        builder.Services.RegisterPage<AboutPage, AboutViewModel>();

        return builder;
    }

    static IServiceCollection RegisterPage<TPage, TViewModel>(this IServiceCollection services, string name = default)
        where TPage : BasePage where TViewModel : BaseViewModel
    {
        Routing.UnRegisterRoute(name ?? nameof(TPage));
        Routing.RegisterRoute(name ?? nameof(TPage), typeof(TPage));
        services.AddTransient<TPage>();
        services.AddTransient<TViewModel>();
        return services;
    }
}