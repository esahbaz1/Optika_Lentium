using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optika_Lentium.Data.Migrations
{
    /// <inheritdoc />
    public partial class migracijanovaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narucivanje_Placanje_placanjeId",
                table: "Narucivanje");

            migrationBuilder.DropIndex(
                name: "IX_Narucivanje_placanjeId",
                table: "Narucivanje");

            migrationBuilder.DropColumn(
                name: "placanjeId",
                table: "Narucivanje");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "placanjeId",
                table: "Narucivanje",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Narucivanje_placanjeId",
                table: "Narucivanje",
                column: "placanjeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Narucivanje_Placanje_placanjeId",
                table: "Narucivanje",
                column: "placanjeId",
                principalTable: "Placanje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
