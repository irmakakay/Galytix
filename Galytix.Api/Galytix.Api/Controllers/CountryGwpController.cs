using System.Diagnostics.CodeAnalysis;
using Galytix.Api.Model.Web;
using Galytix.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Galytix.Api.Controllers;

[ApiController]
[Route("api/server/gwp")]
[ExcludeFromCodeCoverage]
public class CountryGwpController : ControllerBase
{
    private readonly IGwpDataService _dataService;

    public CountryGwpController(IGwpDataService dataService)
        => _dataService = dataService;

    [HttpPost("avg")]
    [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAverageGwp(GetAverageGwpRequest request)
    {
        var result = await _dataService.GetAverageGwpByCountryAndLinesOfBusiness(request);
        
        return Ok(result);
    }
}