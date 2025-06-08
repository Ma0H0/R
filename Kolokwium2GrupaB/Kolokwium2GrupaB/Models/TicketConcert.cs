using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2GrupaB.Models;

[Table("TicketConcert")]
public class TicketConcert
{
    [Key]
    public int Id { get; set; }
    [ForeignKey(nameof(Ticket))]
    public int TicketId { get; set; }
    [ForeignKey(nameof(Concert))]
    public int ConcertId { get; set; }
    public double Price { get; set; }
    
    public Ticket Ticket { get; set; } = null!;
    public Concert Concert { get; set; } = null!;
    
    public ICollection<PurchasedTicket> PurchasedTickets { get; set; }
    
}