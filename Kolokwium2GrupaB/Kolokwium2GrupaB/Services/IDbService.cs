using Kolokwium2GrupaB.DTOs;

namespace Kolokwium2GrupaB.Services;

public interface IDbService
{
    Task<CustomerDTO> GetCustomerById(int CustomerId);   
    Task<CustomerAddDTO> AddCustomer(CustomerAddDTO customer);
}