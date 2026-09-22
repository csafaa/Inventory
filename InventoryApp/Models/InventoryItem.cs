using CommunityToolkit.Mvvm.ComponentModel;

namespace InventoryApp.Models;

public partial class InventoryItem : ObservableObject
{
    [ObservableProperty]
    private int itemId;

    [ObservableProperty]
    private string itemName = string.Empty;

    [ObservableProperty]
    private int currentQuantity;

    [ObservableProperty]
    private DateTime lastUpdated;
}