using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Models;
using InventoryApp.ViewModels;

namespace InventoryApp.Views;

public partial class InventoryPage : ContentPage
{
    private readonly InventoryListViewModel _viewModel;

    public InventoryPage(
        InventoryListViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.LoadCommand.ExecuteAsync(null);
    }

    private async void OnItemSelected(
        object? sender,
        SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault()
            is not InventoryItem item)
        {
            return;
        }

        await Shell.Current.GoToAsync(
            nameof(InventoryDetailPage),
            new Dictionary<string, object>
            {
                ["Item"] = item
            });

        if (sender is CollectionView collectionView)
        {
            collectionView.SelectedItem = null;
        }
    }
}