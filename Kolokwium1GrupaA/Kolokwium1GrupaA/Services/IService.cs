using Microsoft.AspNetCore.Mvc;
using Kolokwium1GrupaA.Models.DTOs;

namespace Kolokwium1GrupaA.Services;

public interface IService
{
 Task<IActionResult> Get_Appointment(int id);   
}