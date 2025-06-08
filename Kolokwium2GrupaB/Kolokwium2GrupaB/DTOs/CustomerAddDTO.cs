namespace Kolokwium2GrupaB.DTOs;

public class CustomerAddDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public String? PhoneNumber { get; set; }
    public List<PurchaseAddDTO> Purchases { get; set; }
}

public class PurchaseAddDTO
{
    public int SeatNumber { get; set; }
    public string ConcertName { get; set; }
    public double Price { get; set; }
    
}