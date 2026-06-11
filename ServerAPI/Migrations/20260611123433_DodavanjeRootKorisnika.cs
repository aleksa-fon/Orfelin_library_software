using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orfelin.API.Migrations
{
    /// <inheritdoc />
    public partial class DodavanjeRootKorisnika : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Zaposleni",
                columns: new[] { "Id", "Aktivan", "Ime", "PasswordHash", "Prezime", "Uloga", "Username", "VremeIzmene", "VremeKreiranja" },
                values: new object[] { 1, true, "Admin", "$2a$11$zbcmZZTbkH7pXyyy7ehKYuUY9oOipOnWUpFS1qBEhpAm6kxoEDLCu", "Admin", "Rukovodilac", "admin", null, new DateTime(2026, 6, 11, 14, 34, 32, 636, DateTimeKind.Local).AddTicks(2301) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Zaposleni",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
