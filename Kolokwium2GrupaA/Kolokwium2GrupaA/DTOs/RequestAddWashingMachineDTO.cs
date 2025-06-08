namespace Kolokwium2GrupaA.DTOs;

public class RequestAddWashingMachineDTO
{
    public AddWashingMachineDTO WashingMachine { get; set; }
    public List<AvailableProgramDTO> AvailablePrograms { get; set; }
}

public class AddWashingMachineDTO
{
    public double MaxWeight { get; set; }
    public string SerialNumber { get; set; }
}

public class AvailableProgramDTO
{
    public string ProgramName { get; set; }
    public double price { get; set; }
}