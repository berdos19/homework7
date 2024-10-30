using DriversManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DriversManagement.API.Interfaces;

public interface IDriverService
{
    Task<ICollection<Driver>> GetAllDrivers(DriverFilter filter, int skip, int take);
    Task<ICollection<Vehicle>> FilterVehicles(string? model, int? year, string? driverFirstName);
}