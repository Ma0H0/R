﻿// <auto-generated />
using System;
using Kolokwium2GrupaB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kolokwium2GrupaB.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kolokwium2GrupaB.Models.Concert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AvailableTickets")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Concert");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableTickets = 3,
                            Date = new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Created"
                        },
                        new
                        {
                            Id = 2,
                            AvailableTickets = 3,
                            Date = new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ongoing"
                        },
                        new
                        {
                            Id = 3,
                            AvailableTickets = 3,
                            Date = new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Completed"
                        });
                });

            modelBuilder.Entity("Kolokwium2GrupaB.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "John",
                            LastName = "Doe",
                            PhoneNumber = "08888888888"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Jane",
                            LastName = "Doe",
                            PhoneNumber = "08888888888"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Julie",
                            LastName = "Doe",
                            PhoneNumber = "null"
                        });
                });

            modelBuilder.Entity("Kolokwium2GrupaB.Models.PurchasedTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TicketConcertId")
                        .HasColumnType("int");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TicketConcertId");

                    b.HasIndex("TicketId");

                    b.ToTable("PurchasedTicket");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 3,
                            PurchaseDate = new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TicketConcertId = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            PurchaseDate = new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TicketConcertId = 2
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 1,
                            PurchaseDate = new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TicketConcertId = 3
                        });
                });

            modelBuilder.Entity("Kolokwium2GrupaB.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ticket");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SeatNumber = 1,
                            SerialNumber = "A2"
                        },
                        new
                        {
                            Id = 2,
                            SeatNumber = 2,
                            SerialNumber = "B2"
                        },
                        new
                        {
                            Id = 3,
                            SeatNumber = 3,
                            SerialNumber = "C2"
                        });
                });

            modelBuilder.Entity("Kolokwium2GrupaB.Models.TicketConcert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConcertId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConcertId");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketConcert");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcertId = 1,
                            Price = 4.3200000000000003,
                            TicketId = 1
                        },
                        new
                        {
                            Id = 2,
                            ConcertId = 2,
                            Price = 4.3099999999999996,
                            TicketId = 2
                        },
                        new
                        {
                            Id = 3,
                            ConcertId = 3,
                            Price = 4.2999999999999998,
                            TicketId = 3
                        });
                });

            modelBuilder.Entity("Kolokwium2GrupaB.Models.PurchasedTicket", b =>
                {
                    b.HasOne("Kolokwium2GrupaB.Models.Customer", "Customer")
                        .WithMany("PurchaseTickets")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium2GrupaB.Models.TicketConcert", "TicketConcert")
                        .WithMany("PurchasedTickets")
                        .HasForeignKey("TicketConcertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium2GrupaB.Models.Ticket", null)
                        .WithMany("TicketConcert")
                        .HasForeignKey("TicketId");

                    b.Navigation("Customer");

                    b.Navigation("TicketConcert");
                });

            modelBuilder.Entity("Kolokwium2GrupaB.Models.TicketConcert", b =>
                {
                    b.HasOne("Kolokwium2GrupaB.Models.Concert", "Concert")
                        .WithMany("TicketConcerts")
                        .HasForeignKey("ConcertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium2GrupaB.Models.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concert");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Kolokwium2GrupaB.Models.Concert", b =>
                {
                    b.Navigation("TicketConcerts");
                });

            modelBuilder.Entity("Kolokwium2GrupaB.Models.Customer", b =>
                {
                    b.Navigation("PurchaseTickets");
                });

            modelBuilder.Entity("Kolokwium2GrupaB.Models.Ticket", b =>
                {
                    b.Navigation("TicketConcert");
                });

            modelBuilder.Entity("Kolokwium2GrupaB.Models.TicketConcert", b =>
                {
                    b.Navigation("PurchasedTickets");
                });
#pragma warning restore 612, 618
        }
    }
}
