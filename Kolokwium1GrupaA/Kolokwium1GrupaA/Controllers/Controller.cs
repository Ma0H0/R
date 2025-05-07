using Microsoft.AspNetCore.Mvc;
using Kolokwium1GrupaA.Models.DTOs;
using Kolokwium1GrupaA.Services;

namespace Kolokwium1GrupaA.Controllers;

[Route("api")]
[ApiController]
public class Controller: ControllerBase
{
    private readonly IService _service;

    public Controller(IService Service)
    {
        _service = Service;
    }
    [HttpGet("appointments/{id}")]
    public async Task<IActionResult> GetAppointments(int id)
    {
        var rentals = await _service.Get_Appointment(id);
        return Ok(rentals);
    }
    
    
}