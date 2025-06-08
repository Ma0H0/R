using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2GrupaA.Models;

[Table("WashingMachine")]
public class WashingMachine
{
    [Key]
    public int Id { get; set; }
    public double MaxWeight { get; set; }
    public string SerialNumber { get; set; }
    
    public ICollection<AvailableProgram> Programs { get; set; }
    
}