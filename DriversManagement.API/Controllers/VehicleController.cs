using DriversManagement.API.Interfaces;
using DriversManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DriversManagement.API.Controllers
{
    [ApiController]
    [Route("vehicles")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Vehicle>>> GetVehicles(
            [FromQuery] string sortOrder = "asc",
            [FromQuery] int skip = 0,
            [FromQuery] int take = 10)
        {
            var vehicles = await _vehicleService.GetAllVehicles(sortOrder, skip, take);
            return Ok(vehicles);
        }

        [HttpGet("{year}/{model}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int year, string model)
        {
            var vehicle = await _vehicleService.GetVehicleByYearAndModel(year, model);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }
    }
}
