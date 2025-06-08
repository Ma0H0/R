using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kolokwium2GrupaB.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableTickets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concert", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketConcert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    ConcertId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketConcert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketConcert_Concert_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Concert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketConcert_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchasedTicket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketConcertId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasedTicket_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasedTicket_TicketConcert_TicketConcertId",
                        column: x => x.TicketConcertId,
                        principalTable: "TicketConcert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasedTicket_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Concert",
                columns: new[] { "Id", "AvailableTickets", "Date", "Name" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Created" },
                    { 2, 3, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ongoing" },
                    { 3, 3, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "John", "Doe", "08888888888" },
                    { 2, "Jane", "Doe", "08888888888" },
                    { 3, "Julie", "Doe", "null" }
                });

            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "Id", "SeatNumber", "SerialNumber" },
                values: new object[,]
                {
                    { 1, 1, "A2" },
                    { 2, 2, "B2" },
                    { 3, 3, "C2" }
                });

            migrationBuilder.InsertData(
                table: "TicketConcert",
                columns: new[] { "Id", "ConcertId", "Price", "TicketId" },
                values: new object[,]
                {
                    { 1, 1, 4.3200000000000003, 1 },
                    { 2, 2, 4.3099999999999996, 2 },
                    { 3, 3, 4.2999999999999998, 3 }
                });

            migrationBuilder.InsertData(
                table: "PurchasedTicket",
                columns: new[] { "Id", "CustomerId", "PurchaseDate", "TicketConcertId", "TicketId" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 2, 2, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 3, 1, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedTicket_CustomerId",
                table: "PurchasedTicket",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedTicket_TicketConcertId",
                table: "PurchasedTicket",
                column: "TicketConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedTicket_TicketId",
                table: "PurchasedTicket",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketConcert_ConcertId",
                table: "TicketConcert",
                column: "ConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketConcert_TicketId",
                table: "TicketConcert",
                column: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchasedTicket");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "TicketConcert");

            migrationBuilder.DropTable(
                name: "Concert");

            migrationBuilder.DropTable(
                name: "Ticket");
        }
    }
}
