using InventoryApp.Models;

namespace InventoryApp.Services;

public class MockInventoryService : IInventoryService
{
    private readonly List<InventoryItem> _items =
    [
        new InventoryItem
        {
            ItemId = 1,
            ItemName = "Laptop",
            CurrentQuantity = 25,
            LastUpdated = DateTime.UtcNow
        },
        new InventoryItem
        {
            ItemId = 2,
            ItemName = "Keyboard",
            CurrentQuantity = 50,
            LastUpdated = DateTime.UtcNow
        },
        new InventoryItem
        {
            ItemId = 3,
            ItemName = "Mouse",
            CurrentQuantity = 75,
            LastUpdated = DateTime.UtcNow
        },
        new InventoryItem
        {
            ItemId = 4,
            ItemName = "Monitor",
            CurrentQuantity = 15,
            LastUpdated = DateTime.UtcNow
        }
    ];

    public async Task<IReadOnlyList<InventoryItem>> GetInventoryAsync()
    {
        //to simulate a network call.
        await Task.Delay(500);

        return _items;
    }

    public async Task<InventoryItem> UpdateQuantityAsync(
        int itemId,
        int quantity)
    {
        await Task.Delay(300);

        var item = _items.FirstOrDefault(x => x.ItemId == itemId);

        if (item == null)
        {
            throw new KeyNotFoundException(
                $"Inventory item {itemId} was not found.");
        }

        item.CurrentQuantity = quantity;
        item.LastUpdated = DateTime.UtcNow;

        return item;
    }
}