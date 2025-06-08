namespace Kolokwium2GrupaB.DTOs;

public class CustomerDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public String? phoneNumber { get; set; }
    public List<PurchaseDTO> Purchases { get; set; }
}

public class PurchaseDTO
{
    public DateTime Date { get; set; }
    public double Price { get; set; }
    public TicketDTO Ticket { get; set; }
    public ConcertDTO Concert { get; set; }
}

public class TicketDTO
{
    public string SerialNumber { get; set; }
    public int seatNumber { get; set; }
}

public class ConcertDTO
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
}