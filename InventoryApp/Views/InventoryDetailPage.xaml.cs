using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.ViewModels;

namespace InventoryApp.Views;

public partial class InventoryDetailPage : ContentPage
{
    public InventoryDetailPage(
        InventoryDetailViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}