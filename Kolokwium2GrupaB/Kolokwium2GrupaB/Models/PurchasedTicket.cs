using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2GrupaB.Models;

[Table("PurchasedTicket")]
public class PurchasedTicket
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("TicketConcert")] 
    public int TicketConcertId { get; set; }
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public DateTime PurchaseDate { get; set; }

    public Customer Customer { get; set; } = null!;
    public TicketConcert TicketConcert { get; set; } = null!;

}