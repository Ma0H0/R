using Kolokwium2GrupaA.DTOs;

namespace Kolokwium2GrupaA.Services;

public interface IDbService
{
    Task<CustomerDTO> GetCustomerById(int CustomerId);   
    Task<RequestAddWashingMachineDTO> AddWashingMachine(RequestAddWashingMachineDTO washingMachine);
}