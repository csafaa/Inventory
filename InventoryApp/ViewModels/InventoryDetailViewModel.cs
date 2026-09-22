using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryApp.Models;
using InventoryApp.Services;

namespace InventoryApp.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class InventoryDetailViewModel : ObservableObject
{
    private readonly IInventoryService _inventoryService;

    [ObservableProperty]
    private InventoryItem? item;

    [ObservableProperty]
    private int quantity;

    [ObservableProperty]
    private bool isBusy;

    public InventoryDetailViewModel(
        IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    partial void OnItemChanged(InventoryItem? value)
    {
        if (value != null)
        {
            Quantity = value.CurrentQuantity;
        }
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        if (Item == null || IsBusy)
            return;

        if (Quantity < 0)
        {
            await Shell.Current.DisplayAlert(
                "Invalid quantity",
                "Quantity cannot be negative.",
                "OK");

            return;
        }

        try
        {
            IsBusy = true;

            var updatedItem =
                await _inventoryService.UpdateQuantityAsync(
                    Item.ItemId,
                    Quantity);

            Item = updatedItem;

            await Shell.Current.DisplayAlert(
                "Success",
                "Inventory updated successfully.",
                "OK");

            await Shell.Current.GoToAsync("..");
        }
        catch (KeyNotFoundException)
        {
            await Shell.Current.DisplayAlert(
                "Error",
                "Inventory item was not found.",
                "OK");
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert(
                "Error",
                "Unable to update inventory.",
                "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}