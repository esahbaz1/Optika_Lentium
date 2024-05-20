using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optika_Lentium.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ime",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "korisnikId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "kupacId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "prezime",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "radnikId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "sifra",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "vlasnikId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    lokacijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lokacijaOptikeURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lokacijaKorisnikaURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.lokacijaId);
                });

            migrationBuilder.CreateTable(
                name: "LokacijaKorisnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnikId = table.Column<int>(type: "int", nullable: false),
                    kupacId = table.Column<int>(type: "int", nullable: false),
                    radnikID = table.Column<int>(type: "int", nullable: false),
                    vlasnikID = table.Column<int>(type: "int", nullable: false),
                    lokacijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LokacijaKorisnik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoviKorisnik",
                columns: table => new
                {
                    korisnikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kupacId = table.Column<int>(type: "int", nullable: false),
                    radnikId = table.Column<int>(type: "int", nullable: false),
                    vlasnikId = table.Column<int>(type: "int", nullable: false),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sifra = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoviKorisnik", x => x.korisnikId);
                });

            migrationBuilder.CreateTable(
                name: "Placanje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnikId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    bankovniRacun = table.Column<bool>(type: "bit", nullable: false),
                    iznosPlacanja = table.Column<double>(type: "float", nullable: false),
                    valProizvodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placanje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Placanje_AspNetUsers_korisnikId",
                        column: x => x.korisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PregledKorisnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnikId = table.Column<int>(type: "int", nullable: false),
                    kupacId = table.Column<int>(type: "int", nullable: false),
                    radnikID = table.Column<int>(type: "int", nullable: false),
                    vlasnikID = table.Column<int>(type: "int", nullable: false),
                    pregledId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregledKorisnik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    proizvodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazivProizvod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cijena = table.Column<double>(type: "float", nullable: false),
                    slikaURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kategorija = table.Column<int>(type: "int", nullable: false),
                    tip = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.proizvodId);
                });

            migrationBuilder.CreateTable(
                name: "ProizvodKorisnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnikId = table.Column<int>(type: "int", nullable: false),
                    kupacId = table.Column<int>(type: "int", nullable: false),
                    radnikID = table.Column<int>(type: "int", nullable: false),
                    vlasnikID = table.Column<int>(type: "int", nullable: false),
                    proizvodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProizvodKorisnik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValidacijaProizvoda",
                columns: table => new
                {
                    valProizvodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uspjesnaValidacija = table.Column<bool>(type: "bit", nullable: false),
                    stanjeProizvoda = table.Column<int>(type: "int", nullable: false),
                    narucivanjeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidacijaProizvoda", x => x.valProizvodId);
                });

            migrationBuilder.CreateTable(
                name: "ZakazivanjePregleda",
                columns: table => new
                {
                    pregledId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnikId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    potvrdaZakazivanja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZakazivanjePregleda", x => x.pregledId);
                    table.ForeignKey(
                        name: "FK_ZakazivanjePregleda_AspNetUsers_korisnikId",
                        column: x => x.korisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NacinPlacanja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrsta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    placanjeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NacinPlacanja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NacinPlacanja_Placanje_placanjeId",
                        column: x => x.placanjeId,
                        principalTable: "Placanje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narucivanje",
                columns: table => new
                {
                    narucivanjeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ukupniRacunZaPlacanje = table.Column<double>(type: "float", nullable: false),
                    korisnikId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    proizvodId = table.Column<int>(type: "int", nullable: false),
                    placanjeId = table.Column<int>(type: "int", nullable: false),
                    zaliha = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narucivanje", x => x.narucivanjeId);
                    table.ForeignKey(
                        name: "FK_Narucivanje_AspNetUsers_korisnikId",
                        column: x => x.korisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Narucivanje_Placanje_placanjeId",
                        column: x => x.placanjeId,
                        principalTable: "Placanje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Popust",
                columns: table => new
                {
                    popustId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brojOstvarenihNarudzbi = table.Column<int>(type: "int", nullable: false),
                    placanjeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Popust", x => x.popustId);
                    table.ForeignKey(
                        name: "FK_Popust_Placanje_placanjeId",
                        column: x => x.placanjeId,
                        principalTable: "Placanje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NacinPlacanja_placanjeId",
                table: "NacinPlacanja",
                column: "placanjeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Narucivanje_korisnikId",
                table: "Narucivanje",
                column: "korisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Narucivanje_placanjeId",
                table: "Narucivanje",
                column: "placanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Placanje_korisnikId",
                table: "Placanje",
                column: "korisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Popust_placanjeId",
                table: "Popust",
                column: "placanjeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZakazivanjePregleda_korisnikId",
                table: "ZakazivanjePregleda",
                column: "korisnikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lokacija");

            migrationBuilder.DropTable(
                name: "LokacijaKorisnik");

            migrationBuilder.DropTable(
                name: "NacinPlacanja");

            migrationBuilder.DropTable(
                name: "Narucivanje");

            migrationBuilder.DropTable(
                name: "NoviKorisnik");

            migrationBuilder.DropTable(
                name: "Popust");

            migrationBuilder.DropTable(
                name: "PregledKorisnik");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "ProizvodKorisnik");

            migrationBuilder.DropTable(
                name: "ValidacijaProizvoda");

            migrationBuilder.DropTable(
                name: "ZakazivanjePregleda");

            migrationBuilder.DropTable(
                name: "Placanje");

            migrationBuilder.DropColumn(
                name: "ime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "korisnikId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "kupacId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "prezime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "radnikId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "sifra",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "vlasnikId",
                table: "AspNetUsers");
        }
    }
}
