using Core.Application.DTOs;
using Core.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SrnpController : Controller
{
    private readonly ISrnpResultService _srnpResultService;

    public SrnpController(ISrnpResultService srnpResultService)
    {
        _srnpResultService = srnpResultService;
    }

    [HttpPost]
    [ProducesResponseType(200, Type = typeof(List<SrnpResultDto>))]
    public async Task<IActionResult> GetResult([FromBody] SrnpInputDto srnpInputDto)
    {
        var result = await _srnpResultService.GetResult(srnpInputDto.Srnp!);
        return Ok(result);
    }
}