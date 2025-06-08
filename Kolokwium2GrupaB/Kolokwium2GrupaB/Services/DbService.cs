using Kolokwium2GrupaB.Data;
using Kolokwium2GrupaB.DTOs;
using Kolokwium2GrupaB.Exception;
using Kolokwium2GrupaB.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2GrupaB.Services;

public class DbService: IDbService
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
                    phoneNumber = e.PhoneNumber,
                    Purchases = e.PurchaseTickets.Select(e => new PurchaseDTO()
                    {
                        Date = e.PurchaseDate,
                        Price = e.TicketConcert.Price,
                        Ticket = new TicketDTO()
                        {
                            SerialNumber = e.TicketConcert.Ticket.SerialNumber,
                            seatNumber = e.TicketConcert.Ticket.SeatNumber,
                        },
                        Concert = new ConcertDTO()
                        {
                            Date = e.TicketConcert.Concert.Date,
                            Name = e.TicketConcert.Concert.Name,
                        }
                        
                        
                        
                    }).ToList()
                    
                }).FirstOrDefaultAsync(e => e.Id == CustomerId);
        if (customer == null)
            throw new NotFoundException();
        return customer;
    }
    public async Task<CustomerAddDTO> AddCustomer([FromBody] CustomerAddDTO request)
    {
        // 1. Czy klient już istnieje?
        var existingCustomer = await _context.Customers
            .AnyAsync(c => c.Id == request.Id);

        if (existingCustomer)
            throw new ConflictExceptions();

        // 2. Znajdź koncerty po nazwie
        var concertNames = request.Purchases.Select(p => p.ConcertName).Distinct();
        var concerts = await _context.Concerts
            .Where(c => concertNames.Contains(c.Name))
            .ToListAsync();

        if (concerts.Count != concertNames.Count())
            throw new NotFoundException("One or more concerts do not exist.");

        // 3. Sprawdź limit 5 biletów
        var tooManyTickets = request.Purchases
            .GroupBy(p => p.ConcertName)
            .Any(g => g.Count() > 5);

        if (tooManyTickets)
            throw new ConflictExceptions();

        // 4. Utwórz klienta
        var customer = new Customer
        {
            
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber
        };

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        // 5. Dodaj bilety i zakupy
        foreach (var purchase in request.Purchases)
        {
            var concert = concerts.First(c => c.Name == purchase.ConcertName);

            // Dodaj bilet
            var ticket = new Ticket
            {
                SerialNumber = Guid.NewGuid().ToString(),
                SeatNumber = purchase.SeatNumber
            };
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            // Przypisz bilet do koncertu
            var ticketConcert = new TicketConcert
            {
                TicketId = ticket.Id,
                ConcertId = concert.Id,
                Price = purchase.Price
            };
            _context.TicketConcerts.Add(ticketConcert);
            await _context.SaveChangesAsync();

            // Przypisz bilet klientowi
            var purchasedTicket = new PurchasedTicket
            {
                TicketConcertId = ticketConcert.Id,
                CustomerId = customer.Id,
                PurchaseDate = DateTime.UtcNow
            };
            _context.PurchasedTickets.Add(purchasedTicket);
        }

        await _context.SaveChangesAsync();

        return request;
    }
}