using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kolowkwium.Models.DTOs;
using Kolowkwium.Services;

namespace Kolowkwium.Controllers
{
    [Route("api")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly IService _service;

        public Controller(IService Service)
        {
            _service = Service;
        }

        [HttpGet("customer/{id}/rentals")]
        public async Task<IActionResult> GetRentals(int id)
        {
            var rentals = await _service.GetRentals(id);
            return Ok(rentals);
        }
        [HttpPost("customer/{id}/rentals")]
        public async Task<IActionResult> AddNewRental(int id, CreateRentalRequestDto createRentalRequest)
        {
            if (!createRentalRequest.Movies.Any())
            {
                return BadRequest("At least one item is required.");
            }

            try
            {
                await _service.AddNewRentalAsync(id, createRentalRequest);
            }
            catch (Exception e)
            {
            }


            return CreatedAtAction(nameof(GetRentals), new { id }, createRentalRequest);
        }    
    }
}
    
