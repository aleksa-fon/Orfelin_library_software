using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orfelin.API.Migrations
{
    /// <inheritdoc />
    public partial class InicijalnaMigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Knjige",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventarniBroj = table.Column<int>(type: "int", nullable: false),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Izdavac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GodinaIzdavanja = table.Column<int>(type: "int", nullable: false),
                    Zanr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojStrana = table.Column<int>(type: "int", nullable: false),
                    DostupnoKopija = table.Column<int>(type: "int", nullable: false),
                    UkupanBrojKopija = table.Column<int>(type: "int", nullable: false),
                    DatumNabavke = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremeKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremeIzmene = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjige", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojClanskeKarte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumClanstva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false),
                    VremeKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremeIzmene = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zaposleni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uloga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false),
                    VremeKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremeIzmene = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposleni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pozajmice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KnjigaId = table.Column<int>(type: "int", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    ZaposleniId = table.Column<int>(type: "int", nullable: false),
                    RokVracanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumPozajmice = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumVracanja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VremeKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremeIzmene = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozajmice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pozajmice_Knjige_KnjigaId",
                        column: x => x.KnjigaId,
                        principalTable: "Knjige",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pozajmice_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pozajmice_Zaposleni_ZaposleniId",
                        column: x => x.ZaposleniId,
                        principalTable: "Zaposleni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pozajmice_KnjigaId",
                table: "Pozajmice",
                column: "KnjigaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pozajmice_KorisnikId",
                table: "Pozajmice",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Pozajmice_ZaposleniId",
                table: "Pozajmice",
                column: "ZaposleniId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pozajmice");

            migrationBuilder.DropTable(
                name: "Knjige");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Zaposleni");
        }
    }
}
