using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optika_Lentium.Data.Migrations
{
    /// <inheritdoc />
    public partial class migracijanova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZakazivanjePregleda_AspNetUsers_korisnikId",
                table: "ZakazivanjePregleda");

            migrationBuilder.DropIndex(
                name: "IX_ZakazivanjePregleda_korisnikId",
                table: "ZakazivanjePregleda");

            migrationBuilder.DropColumn(
                name: "korisnikId",
                table: "ZakazivanjePregleda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "korisnikId",
                table: "ZakazivanjePregleda",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ZakazivanjePregleda_korisnikId",
                table: "ZakazivanjePregleda",
                column: "korisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_ZakazivanjePregleda_AspNetUsers_korisnikId",
                table: "ZakazivanjePregleda",
                column: "korisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
