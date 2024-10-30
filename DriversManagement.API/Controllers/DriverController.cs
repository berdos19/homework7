using DriversManagement.API.DTOs;
using DriversManagement.API.Interfaces;
using DriversManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DriversManagement.API.Controllers;

[ApiController]
[Route("drivers")]
public class DriverController : ControllerBase
{
    private readonly IDriverService _driverService;

    public DriverController(IDriverService driverService)
    {
        _driverService = driverService;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<DriverDTO>>> GetDrivers(
        [FromQuery] string? firstName,
        [FromQuery] string? lastName,
        [FromQuery] string? licenceNumber,
        [FromQuery] string? searchContext,
        [FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var filter = new DriverFilter
        {
            FirstName = firstName,
            LastName = lastName,
            LicenceNumber = licenceNumber,
            SearchContext = searchContext
        };
        return Ok((await _driverService.GetAllDrivers(filter, skip, take))
            .Select(x => new DriverDTO()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
            }));
    }

    [HttpGet("vehicles")]
    public async Task<ActionResult<ICollection<Vehicle>>> GetVehicles(
        [FromQuery] string? model,
        [FromQuery] int? year, 
        [FromQuery] string? driverFirstName)
    {
        return Ok(await _driverService.FilterVehicles(model, year, driverFirstName));
    }
    
    [HttpPost]
    public ActionResult AddDriver(DriverDTO driver)
    {
        return Ok();
    }
}