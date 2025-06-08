using Kolokwium2GrupaA.Models;

namespace Kolokwium2GrupaA.DTOs;

public class CustomerDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public List<PurchaseDTO> Purchases { get; set; }
}

public class PurchaseDTO
{
    public DateTime Date { get; set; }
    public int Rating {get; set;}
    public double Price { get; set; }
    public WashingMachineDTO WashingMachine { get; set; }
    public ProgramDTO Program { get; set; }
}

public class WashingMachineDTO
{
    public string Serial { get; set; }
    public double maxWeight { get; set; }
}

public class ProgramDTO
{
    public String Name { get; set; }
    public int duration { get; set; }
}