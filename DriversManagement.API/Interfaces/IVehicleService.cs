using DriversManagement.API.Models;

namespace DriversManagement.API.Interfaces;

public interface IVehicleService
{
    Task<ICollection<Vehicle>> GetAllVehicles(string sortOrder, int skip, int take);
    Task<Vehicle> GetVehicleByYearAndModel(int year, string model);
}
