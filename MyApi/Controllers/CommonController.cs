using Application.Contracts;
using Application.Requests;
using Application.Responses;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers;

[ApiController]
[Route("api/v1/commons")] //todo: applying api versioning, authen, author
public class CommonController(ICommonService commonService) : ControllerBase
{
    [HttpGet("categories")]
    public async Task<IActionResult> GetCategoriesForDropdownList(
        [FromQuery] string? filterKeyword)
    {
        var items = await commonService.GetCategories(filterKeyword);
        return Ok(new { Items = items});
    }

}
