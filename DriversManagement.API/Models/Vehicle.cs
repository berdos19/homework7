namespace DriversManagement.API.Models;

public class Vehicle
{
    public int Id { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Engine { get; set; }
    public int FuelCapacity { get; set; }

    public Driver Driver { get; set; }
}