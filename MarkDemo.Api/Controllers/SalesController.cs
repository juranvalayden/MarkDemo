using MarkDemo.Application.Dtos;
using MarkDemo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarkDemo.Api.Controllers;

[ApiController]
[Route("api/sales")]
public class SalesController : ControllerBase
{
    private readonly ILogger<SalesController> _logger;
    private readonly ISalesOrderService _salesOrderService;

    public SalesController(ILogger<SalesController> logger, ISalesOrderService salesOrderService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesOrderService = salesOrderService ?? throw new ArgumentNullException(nameof(salesOrderService));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SalesOrderHeaderDto>>> GetSalesOrderHeadersAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var dtos = await _salesOrderService.GetSalesOrderHeadersAsync(cancellationToken);
            return Ok(dtos);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred in GetSalesOrderHeadersAsync");
            return BadRequest();
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SalesOrderHeaderDto>> GetSalesOrderHeaderByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            var dto = await _salesOrderService.GetSalesOrderHeaderByIdAsync(id, cancellationToken);

            if (dto == null) return NotFound();

            return Ok(dto);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred in GetSalesOrderHeaderByIdAsync");
            return BadRequest();
        }
    }
}
