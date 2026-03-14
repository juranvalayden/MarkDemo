using Microsoft.AspNetCore.Mvc;

namespace MarkDemo.Api.Controllers;

[ApiController]
[Route("api/sales")]
public class SalesController : ControllerBase
{
    private readonly ILogger<SalesController> _logger;

    public SalesController(ILogger<SalesController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public int GetAllSales()
    {
        return 10;
    }

    [HttpGet("{id:int}")]
    public int GetSales(int id)
    {
        return id;
    }
}
