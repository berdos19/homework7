
namespace DriversManagement.API;

public class DriverFilter
{
    public string? SearchContext { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? LicenceNumber { get; set; }
    public IEnumerable<int> CategoryIds { get; set; }
}

//public record Filter(string Name, string Position, int Salary);