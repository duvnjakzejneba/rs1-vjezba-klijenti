using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KlijentiVjezba.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klijenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumKreiranja = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijenti", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Klijenti",
                columns: new[] { "Id", "DatumKreiranja", "Email", "Grad", "Naziv" },
                values: new object[,]
                {
                    { 1, new DateOnly(2026, 11, 17), "klijen1@gmail.com", "Sarajevo", "Klijent 1" },
                    { 2, new DateOnly(2026, 11, 17), "klijen2@gmail.com", "Mostar", "Klijent 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klijenti");
        }
    }
}
