using DriversManagement.API.Models;

namespace DriversManagement.API.Interfaces;

public interface IRepository
{
    IQueryable<T> GetAll<T>() where T : class;
    Task<IQueryable<Vehicle>> GetVehiclesAsync(string sortOrder, int skip, int take);
}