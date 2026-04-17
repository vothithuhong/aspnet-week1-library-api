using AspNetWeek1.Api.Services;
using Microsoft.AspNetCore.Mvc;
namespace AspNetWeek1.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookService _bookService;


    public BooksController(BookService bookService)
    {
        _bookService = bookService;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var books = _bookService.GetAll()
            .Select(b => new
            {
                b.Id,
                b.Title,
                b.Author,
                b.Category,
                b.Year,
                b.Quantity,
                Status = _bookService.GetStockStatus(b.Quantity)
            });
        return Ok(books);
    }


    [HttpGet("stats")]
    public IActionResult GetStats()
    {
        return Ok(_bookService.GetStats());
    }
}
