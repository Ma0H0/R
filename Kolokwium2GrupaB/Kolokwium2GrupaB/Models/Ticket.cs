using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2GrupaB.Models;

[Table("Ticket")]
public class Ticket
{
    [Key]
    public int Id { get; set; }
    public String SerialNumber { get; set; }
    public int SeatNumber { get; set; }
    
    public ICollection<PurchasedTicket> TicketConcert { get; set; }
    
}