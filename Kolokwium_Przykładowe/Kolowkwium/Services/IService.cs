using Microsoft.AspNetCore.Mvc;
using Kolowkwium.Models.DTOs;

namespace Kolowkwium.Services;

public interface IService
{
    Task<IActionResult> GetRentals(int id);
    Task AddNewRentalAsync(int customerId, CreateRentalRequestDto rentalRequest);
    
}