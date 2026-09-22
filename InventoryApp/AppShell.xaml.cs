using InventoryApp.Views;
namespace InventoryApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(
            nameof(InventoryDetailPage),
            typeof(InventoryDetailPage));
    }
}