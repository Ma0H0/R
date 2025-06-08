using System.Runtime.Intrinsics.X86;
using Kolokwium2GrupaA.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2GrupaA.Data;

public class DatabaseContext : DbContext

{
    
    public DbSet<AvailableProgram> AvailablePrograms { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<ProgramW> Programs { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
    public DbSet<WashingMachine> WashingMachines { get; set; }
    
    
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
            new Customer() { Id = 3, FirstName = "Julie", LastName = "Doe",PhoneNumber = "null" }
        });

        modelBuilder.Entity<WashingMachine>().HasData(new List<WashingMachine>()
        {
            new WashingMachine(){Id = 1, MaxWeight = 2.5, SerialNumber = "AB2"},
            new WashingMachine(){Id = 2, MaxWeight = 1.5, SerialNumber = "AB3"},
            new WashingMachine(){Id = 3, MaxWeight = 3.5, SerialNumber = "AB1"}

        });
        modelBuilder.Entity<ProgramW>().HasData(new List<ProgramW>()
        {
            new ProgramW(){Id = 1, Name = "Program1", DurationMinutes = 4, TemperatureCelsius = 3},
            new ProgramW(){Id = 2, Name = "Program2", DurationMinutes = 4, TemperatureCelsius = 3},
            new ProgramW(){Id = 3, Name = "Program3", DurationMinutes = 4, TemperatureCelsius = 3},

        });
        modelBuilder.Entity<PurchaseHistory>().HasData(new List<PurchaseHistory>()
        {
            new PurchaseHistory(){Id = 1, AvailableProgramId = 1,CustomerId = 1,PurchaseDate = DateTime.Parse("2025-05-01"),Rating = 3},
            new PurchaseHistory(){Id = 2, AvailableProgramId = 2,CustomerId = 2,PurchaseDate = DateTime.Parse("2025-05-01"),Rating = 3},
            new PurchaseHistory(){Id = 3, AvailableProgramId = 3,CustomerId = 3,PurchaseDate = DateTime.Parse("2025-05-01"),Rating = 3}
            
        });

        modelBuilder.Entity<AvailableProgram>().HasData(new List<AvailableProgram>()
        {
            new AvailableProgram(){Id = 1,Price = 2.4,ProgramWId = 1,WashingMashineId = 1},
            new AvailableProgram(){Id = 2,Price = 2.4,ProgramWId = 2,WashingMashineId = 2},
            new AvailableProgram(){Id = 3,Price = 2.4,ProgramWId = 3,WashingMashineId = 3}
        });


    }


}