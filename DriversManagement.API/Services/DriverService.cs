using DriversManagement.API.Interfaces;
using DriversManagement.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriversManagement.API.Services;

public class DriverService : IDriverService
{
    private readonly IRepository _repository;

    public DriverService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<Driver>> GetAllDrivers(DriverFilter filter, int skip, int take)
    {
        // hardcode
        filter.CategoryIds = [2, 4, 5];
        string[] categories = ["A", "B", "T"];
        var categoryHashSet = categories.ToHashSet();
        
        var drivers = _repository.GetAll<Driver>()
            .Include(d => d.Category)
            .AsQueryable();

        if (filter.SearchContext != null)
        {
            drivers = drivers.Where(d =>
                (d.FirstName + " " + d.LastName + " " + d.DateOfBirth + " " + d.LicenceNumber + " " +
                 d.Category).Contains(filter.SearchContext));
        }
        else
        {
            if (filter.FirstName != null)
            {
                // SQL: where [d].FirstName like '%'+@filteName+'%'
                drivers = drivers.Where(d => d.FirstName.Contains(filter.FirstName));
            }

            if (filter.LastName != null)
            {
                drivers = drivers.Where(d => d.LastName.Contains(filter.LastName));
            }

            if (filter.LicenceNumber != null)
            {
                drivers = drivers.Where(d => d.LicenceNumber.StartsWith(filter.LicenceNumber));
            }
        }
        
        var ids = _repository.GetAll<VehicleCategory>()
            .Where(x => categoryHashSet.Contains(x.Symbol))
            .Select(x => x.Id);
        drivers = drivers.Where(d => ids.Contains(d.Category.Id));

        drivers = drivers.OrderBy(d => d.LastName).ThenBy(d => d.FirstName);
            
        return await drivers.Skip(skip)
            .Take(take)
            .ToArrayAsync();
    }

    public Task<ICollection<Vehicle>> FilterVehicles(string? model, int? year, string? driverFirstName)
    {
        // TODO
    }
}

/*

_context.Drivers = IQueryable<Driver> = generate SQL script

LINQ to SQL
_context.Drivers.Where(d => d.LastName == "Test"); = SQL: select * from [Drivers] where LastName = 'Test'


var list = _context.Drivers.Where(d => d.Id == 3).Select(d => d.FirstName);
SQL: select d.FirstName from [Drivers] d where d.Id = 3;
list = list.Where(d => d.FirstName.Contains("A"));
SQL: select d.FirstName from [Drivers] d where d.Id = 3 and d.FirstName like '%A%';

list.ToList()              -> execute SQL script
    .ToArray()
    .ToDictionary()














*/