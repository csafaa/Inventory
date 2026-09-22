using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryApp.Models;
using InventoryApp.Services;

namespace InventoryApp.ViewModels;

public partial class InventoryListViewModel : ObservableObject
{
    private readonly IInventoryService _inventoryService;

    public ObservableCollection<InventoryItem> Items { get; } = [];

    [ObservableProperty]
    private bool isBusy;

    public InventoryListViewModel(
        IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [RelayCommand]
    private async Task LoadAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            var items =
                await _inventoryService.GetInventoryAsync();

            Items.Clear();

            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert(
                "Error",
                "Unable to load inventory.",
                "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}