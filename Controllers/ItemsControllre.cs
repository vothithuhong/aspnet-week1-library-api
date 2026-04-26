using AspNetWeek1.Stationery.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetWeek1.Stationery.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly ItemService _itemService;

    public ItemsController(ItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var items = _itemService.GetAll()
            .Select(i => new
            {
                i.Id,
                i.Name,
                i.Category,
                i.Quantity,
                i.Price,
                Status = _itemService.GetStockStatus(i.Quantity)
            });

        return Ok(items);
    }

    [HttpGet("stats")]
    public IActionResult GetStats()
    {
        return Ok(_itemService.GetStats());
    }
}