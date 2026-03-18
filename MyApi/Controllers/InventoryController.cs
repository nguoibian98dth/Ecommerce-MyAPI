using Application.Contracts;
using Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers;

[ApiController]
[Route("api/v1/inventories")] //todo: applying api versioning, authen, author
public class InventoryController(IInventoryService inventoryService) : ControllerBase
{
    [HttpPost("reserve")]
    public async Task<IActionResult> Reserve([FromBody] ReserveStockRequest request)
    {
        if (request == null || request.Quantity <= 0)
            return BadRequest("Invalid request");

        await inventoryService.ReserveAsync(request);

        return NoContent();
    }

    [HttpPost("release")]
    public async Task<IActionResult> Release([FromBody] ReleaseStockRequest request)
    {
        if (request == null || request.Quantity <= 0)
            return BadRequest("Invalid request");

        await inventoryService.ReleaseAsync(request);

        return NoContent();
    }

    [HttpPost("adjust")]
    public async Task<IActionResult> Adjust([FromBody] AdjustStockRequest request)
    {
        if (request == null)
            return BadRequest("Invalid request");

        await inventoryService.AdjustStockAsync(request);

        return NoContent();
    }
}
