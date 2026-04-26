using AspNetWeek1.Stationery.Api.Models;

namespace AspNetWeek1.Stationery.Api.Services;

public class ItemService
{
    private readonly List<Item> _items =
    [
        new Item { Id = 1, Name = "Pen", Category = "Writing", Quantity = 10, Price = 1.5m },
        new Item { Id = 2, Name = "Notebook", Category = "Paper", Quantity = 3, Price = 2.0m },
        new Item { Id = 3, Name = "Eraser", Category = "Writing", Quantity = 0, Price = 0.5m },
        new Item { Id = 4, Name = "Marker", Category = "Writing", Quantity = 7, Price = 1.8m }
    ];

    public List<Item> GetAll() => _items;

    public object GetStats()
    {
        return new
        {
            TotalItems = _items.Count,
            TotalQuantity = _items.Sum(x => x.Quantity),
            AvailableItems = _items.Count(x => x.Quantity > 0)
        };
    }

    public string GetStockStatus(int quantity)
    {
        if (quantity <= 0) return "Out of stock";
        if (quantity <= 3) return "Low stock";
        return "Available";
    }
}