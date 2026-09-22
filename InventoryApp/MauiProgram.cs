using InventoryApp.Services;
using InventoryApp.ViewModels;
using InventoryApp.Views;
using Microsoft.Extensions.Logging;

namespace InventoryApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>();

        // Services
        builder.Services.AddSingleton<
            IInventoryService,
            MockInventoryService>();

        // ViewModels
        builder.Services.AddTransient<
            InventoryListViewModel>();

        builder.Services.AddTransient<
            InventoryDetailViewModel>();

        // Pages
        builder.Services.AddTransient<
            InventoryPage>();

        builder.Services.AddTransient<
            InventoryDetailPage>();

        return builder.Build();
    }
}