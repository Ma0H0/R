using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2GrupaA.Models;

[Table ("ProgramW")]
public class ProgramW
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int DurationMinutes { get; set; }
    public int TemperatureCelsius { get; set; }
    
    public ICollection<AvailableProgram> Programs { get; set; }
    
}