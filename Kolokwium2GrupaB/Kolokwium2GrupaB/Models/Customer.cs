﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2GrupaB.Models;

[Table("Customer")]
public class Customer
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }

    public ICollection<PurchasedTicket> PurchaseTickets { get; set; } = null!;

}