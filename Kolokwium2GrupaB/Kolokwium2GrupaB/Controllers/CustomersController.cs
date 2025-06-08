using Kolokwium2GrupaB.DTOs;
using Kolokwium2GrupaB.Exception;
using Kolokwium2GrupaB.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTest2.Controllers;

[ApiController]
[Route("api/Customers")]
public class OrdersController : ControllerBase
{
    private readonly IDbService _dbService;

    public OrdersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(int id)
    {
        try
        {
            var order = await _dbService.GetCustomerById(id);
            return Ok(order);
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
    }
    [HttpPost("")]
    public async Task<IActionResult> AddCustomerController([FromBody] CustomerAddDTO request)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid input data.");
        
     
        return Created("",await _dbService.AddCustomer(request));
    }
}