using Kolokwium2GrupaA.DTOs;
using Kolokwium2GrupaA.Exceptions;
using Kolokwium2GrupaA.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2GrupaA.Controllers;

[ApiController]
[Route("api/Customers")]
public class DbController : ControllerBase
{private readonly IDbService _dbService;

    public DbController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(int id)
    {
        try
        {
            var order = await _dbService.GetCustomerById(id);
            return Ok(order);
        }
        catch (NotFoundException e)
        {
            return NotFound("Customer not found");
        }
    }
    [HttpPost("")]
    public async Task<IActionResult> AddWashingMachine([FromBody] RequestAddWashingMachineDTO washingMachine)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid input data.");
        
     
        return Created("",await _dbService.AddWashingMachine(washingMachine));
    }
    
    
}