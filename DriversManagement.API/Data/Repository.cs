using DriversManagement.API.Interfaces;
using DriversManagement.API.Models;

namespace DriversManagement.API.Data;

public class Repository : IRepository
{
    private readonly DriversContext _context;

    public Repository(DriversContext context)
    {
        _context = context;
    }

    public IQueryable<T> GetAll<T>() where T : class
    {
        return _context.Set<T>();
    }
    public async Task<IQueryable<Vehicle>> GetVehiclesAsync(string sortOrder, int skip, int take)
    {
        var vehicles = _context.Vehicles.AsQueryable();

        if (!string.IsNullOrEmpty(sortOrder))
        {
            vehicles = sortOrder.ToLower() == "desc" ? vehicles.OrderByDescending(v => v.Model) : vehicles.OrderBy(v => v.Model);
        }

        return await Task.FromResult(vehicles.Skip(skip).Take(take));
    }
}