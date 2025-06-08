using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2GrupaB.Models;

[Table("Concert")]
public class Concert
{
    [Key]
    public int Id { get; set; }
    public String Name { get; set; }
    public DateTime Date { get; set; }
    public int AvailableTickets { get; set; }
    
    public ICollection <TicketConcert> TicketConcerts { get; set; }
    
}