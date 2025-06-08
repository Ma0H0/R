using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2GrupaA.Models;

[Table("Customer")]
public class Customer
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    
    public ICollection<PurchaseHistory> PurchaseHistory { get; set; }
    
}