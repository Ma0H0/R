using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2GrupaA.Models;

[Table("PurchaseHistory")]
public class PurchaseHistory
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    [ForeignKey("AvailableProgram")]
    public int AvailableProgramId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int Rating { get; set; }

    public AvailableProgram AvailableProgram { get; set; } = null!;
    
    public Customer Customer { get; set; } = null!;


}