using AspNetWeek1.Api.Models;
namespace AspNetWeek1.Api.Services;
public class BookService
{
    private readonly List<Book> _books =
    [
        new Book { Id = 1, Title = "Clean Code", Author = "Robert C. Martin", Category = "Programming", Year = 2008, Quantity = 5 },
        new Book { Id = 2, Title = "ASP.NET Core Basics", Author = "John Smith", Category = "Web Development", Year = 2022, Quantity = 2 },
        new Book { Id = 3, Title = "Database Design", Author = "Jane Doe", Category = "Database", Year = 2019, Quantity = 0 },
        new Book { Id = 4, Title = "Cloud Fundamentals", Author = "Tom Lee", Category = "Cloud", Year = 2023, Quantity = 7 }
    ];
  public List<Book> GetAll() => _books;
    public object GetStats()
    {
        var totalTitles = _books.Count;
        var totalQuantity = _books.Sum(x => x.Quantity);
        var availableBooks = _books.Count(x => x.Quantity > 0);
        return new
        {
            TotalTitles = totalTitles,
            TotalQuantity = totalQuantity,
            AvailableBooks = availableBooks
        };
    }
    public string GetStockStatus(int quantity)
    {
        if (quantity <= 0) return "Out of stock";
        if (quantity <= 2) return "Low stock";
        return "Available";
    }
}
