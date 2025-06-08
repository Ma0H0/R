using System.Runtime.Intrinsics.X86;
using Kolokwium2GrupaB.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2GrupaB.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Concert> Concerts { get; set; }
    public DbSet<PurchasedTicket> PurchasedTickets { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketConcert> TicketConcerts { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(new List<Customer>()
        {
            new Customer() { Id = 1, FirstName = "John", LastName = "Doe" ,PhoneNumber = "08888888888" },
            new Customer() { Id = 2, FirstName = "Jane", LastName = "Doe", PhoneNumber = "08888888888" },
            new Customer() { Id = 3, FirstName = "Julie", LastName = "Doe",PhoneNumber = "null" },
        });
        
        modelBuilder.Entity<Concert>().HasData(new List<Concert>()
        {
            new Concert() { Id = 1, Name = "Created" ,Date = DateTime.Parse("2025-05-01"),AvailableTickets = 3},
            new Concert() { Id = 2, Name = "Ongoing" ,Date = DateTime.Parse("2025-05-02"),AvailableTickets = 3},
            new Concert() { Id = 3, Name = "Completed",Date = DateTime.Parse("2025-05-03"),AvailableTickets = 3 },
        });
        
        modelBuilder.Entity<PurchasedTicket>().HasData(new List<PurchasedTicket>()
        {
            new PurchasedTicket() {  Id = 1,TicketConcertId = 1,CustomerId = 3,PurchaseDate = DateTime.Parse("2025-05-01")},
            new PurchasedTicket() {  Id = 2,TicketConcertId = 2,CustomerId = 2,PurchaseDate = DateTime.Parse("2025-05-02") },
            new PurchasedTicket() {  Id = 3,TicketConcertId = 3,CustomerId = 1,PurchaseDate = DateTime.Parse("2025-05-03") },
        });
        
        modelBuilder.Entity<Ticket>().HasData(new List<Ticket>()
        {
            new Ticket() { Id = 1, SerialNumber = "A2",SeatNumber = 1},
            new Ticket() { Id = 2, SerialNumber = "B2",SeatNumber = 2},
            new Ticket() { Id = 3, SerialNumber = "C2",SeatNumber = 3},
        });
        
        modelBuilder.Entity<TicketConcert>().HasData(new List<TicketConcert>()
        {
            new TicketConcert() { Id = 1, TicketId = 1, ConcertId = 1, Price = 4.32 },
            new TicketConcert() { Id = 2, TicketId = 2, ConcertId = 2, Price = 4.31},
            new TicketConcert() { Id = 3, TicketId = 3, ConcertId = 3, Price = 4.30},

        });
    }
    
    
}