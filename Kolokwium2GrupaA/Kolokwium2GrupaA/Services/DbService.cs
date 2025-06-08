using Kolokwium2GrupaA.Data;
using Kolokwium2GrupaA.DTOs;
using Kolokwium2GrupaA.Exceptions;
using Kolokwium2GrupaA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2GrupaA.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<CustomerDTO> GetCustomerById(int CustomerId)
    {
        var customer = await _context.Customers
            .Select(e => new CustomerDTO
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                PhoneNumber = e.PhoneNumber,
                Purchases = e.PurchaseHistory.Select(e => new PurchaseDTO()
                {
                   Date = e.PurchaseDate,
                   Rating = e.Rating,
                   Price = e.AvailableProgram.Price,
                   WashingMachine = new WashingMachineDTO()
                   {
                     Serial  = e.AvailableProgram.WashingMachine.SerialNumber,
                     maxWeight = e.AvailableProgram.WashingMachine.MaxWeight
                   },
                   Program = new ProgramDTO()
                   {
                       Name = e.AvailableProgram.ProgramW.Name,
                       duration = e.AvailableProgram.ProgramW.DurationMinutes
                   }
                }).ToList()
            }).FirstOrDefaultAsync(e => e.Id == CustomerId);
        if (customer == null)
            throw new NotFoundException("Customer not found");
        return customer;
    }

    public async Task<RequestAddWashingMachineDTO> AddWashingMachine([FromBody]RequestAddWashingMachineDTO washingMachine)
    {   // 1. Czy klient już istnieje?
        var existingWM = await _context.WashingMachines
            .AnyAsync(c => c.SerialNumber == washingMachine.WashingMachine.SerialNumber);

        if (existingWM)
            throw new ConflictException("Washing machine already exists");

        // 2. Znajdź koncerty po nazwie
        var programsNames = washingMachine.AvailablePrograms.Select(p => p.ProgramName).Distinct();
        var programs = await _context.Programs
            .Where(c => programsNames.Contains(c.Name))
            .ToListAsync();

        if (programs.Count != programsNames.Count())
            throw new NotFoundException("One or more concerts do not exist.");

        if(washingMachine.WashingMachine.MaxWeight < 8)
            throw new ConflictException("Max weight must be greater than 8");
        foreach (var program in washingMachine.AvailablePrograms)
            if (program.price > 25)
                throw new ConflictException("Price must not be greater than 25");

        // 4. Utwórz klienta
        var WM = new WashingMachine
        {
            MaxWeight = washingMachine.WashingMachine.MaxWeight,
            SerialNumber = washingMachine.WashingMachine.SerialNumber,

        };

        _context.WashingMachines.Add(WM);
        await _context.SaveChangesAsync();

        // 5. Dodaj bilety i zakupy
        foreach (var aprogram in washingMachine.AvailablePrograms)
        {
            var program = programs.First(c => c.Name == aprogram.ProgramName);

            // Dodaj bilet
            var AvailableProgram = new AvailableProgram
            {
                ProgramWId = program.Id,
                WashingMashineId = WM.Id,
                Price = aprogram.price,
            };

        }

        await _context.SaveChangesAsync();

        return washingMachine;
        
    }
}