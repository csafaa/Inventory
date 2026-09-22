using InventoryApp.Models;

namespace InventoryApp.Services;

public interface IInventoryService
{
    Task<IReadOnlyList<InventoryItem>> GetInventoryAsync();

    Task<InventoryItem> UpdateQuantityAsync(
        int itemId,
        int quantity);
}