using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kolokwium2GrupaA.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    TemperatureCelsius = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WashingMachine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxWeight = table.Column<double>(type: "float", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WashingMachine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AvailablePrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WashingMashineId = table.Column<int>(type: "int", nullable: false),
                    ProgramWId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailablePrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailablePrograms_ProgramW_ProgramWId",
                        column: x => x.ProgramWId,
                        principalTable: "ProgramW",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailablePrograms_WashingMachine_WashingMashineId",
                        column: x => x.WashingMashineId,
                        principalTable: "WashingMachine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AvailableProgramId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseHistory_AvailablePrograms_AvailableProgramId",
                        column: x => x.AvailableProgramId,
                        principalTable: "AvailablePrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseHistory_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "ProgramW",
                columns: new[] { "Id", "DurationMinutes", "Name", "TemperatureCelsius" },
                values: new object[,]
                {
                    { 1, 4, "Program1", 3 },
                    { 2, 4, "Program2", 3 },
                    { 3, 4, "Program3", 3 }
                });

            migrationBuilder.InsertData(
                table: "WashingMachine",
                columns: new[] { "Id", "MaxWeight", "SerialNumber" },
                values: new object[,]
                {
                    { 1, 2.5, "AB2" },
                    { 2, 1.5, "AB3" },
                    { 3, 3.5, "AB1" }
                });

            migrationBuilder.InsertData(
                table: "AvailablePrograms",
                columns: new[] { "Id", "Price", "ProgramWId", "WashingMashineId" },
                values: new object[,]
                {
                    { 1, 2.3999999999999999, 1, 1 },
                    { 2, 2.3999999999999999, 2, 2 },
                    { 3, 2.3999999999999999, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "PurchaseHistory",
                columns: new[] { "Id", "AvailableProgramId", "CustomerId", "PurchaseDate", "Rating" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, 2, 2, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, 3, 3, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailablePrograms_ProgramWId",
                table: "AvailablePrograms",
                column: "ProgramWId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailablePrograms_WashingMashineId",
                table: "AvailablePrograms",
                column: "WashingMashineId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseHistory_AvailableProgramId",
                table: "PurchaseHistory",
                column: "AvailableProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseHistory_CustomerId",
                table: "PurchaseHistory",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseHistory");

            migrationBuilder.DropTable(
                name: "AvailablePrograms");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "ProgramW");

            migrationBuilder.DropTable(
                name: "WashingMachine");
        }
    }
}
