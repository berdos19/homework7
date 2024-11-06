using DriversManagement.API.Interfaces;
using DriversManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DriversManagement.API.Services;

public class VehicleService : IVehicleService
{
    private readonly IRepository _repository;

    public VehicleService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<Vehicle>> GetAllVehicles(string sortOrder, int skip, int take)
    {
        var vehiclesQuery = await _repository.GetVehiclesAsync(sortOrder, skip, take);
        return await vehiclesQuery.ToListAsync(); 
    }

    public async Task<Vehicle> GetVehicleByYearAndModel(int year, string model)
    {
        return await _repository.GetAll<Vehicle>().FirstOrDefaultAsync( v => v.Year == year && v.Model == model);
    }
}