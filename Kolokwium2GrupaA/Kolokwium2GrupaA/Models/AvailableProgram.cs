using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2GrupaA.Models;

[Table("AvailablePrograms")]
public class AvailableProgram
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("WashingMachine")]
    public int WashingMashineId { get; set; }
    [ForeignKey("ProgramW")]
    public int ProgramWId { get; set; }
    public double Price { get; set; }

    public WashingMachine WashingMachine { get; set; } = null!;
    public ProgramW ProgramW { get; set; } = null!;
    
    public ICollection<PurchaseHistory> PurchaseHistory { get; set; }
}