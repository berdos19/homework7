using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriversManagement.API.Models;

[Table("Drivers")]
public class Driver
{
    [Key] // primary key
    public int Id { get; set; }
    [Required]
    [StringLength(20, ErrorMessage = "Max length is 20")]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }

    [NotMapped] // not add to database
    public string FullName => FirstName + " " + LastName;

    public VehicleCategory Category { get; set; }
    
    public int Salary { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? LicenceNumber { get; set; }
}






/*class Book
{
    public ICollection<Author> Author { get; set; }
}
class Author
{
    public ICollection<Book> Book { get; set; }
}*/









