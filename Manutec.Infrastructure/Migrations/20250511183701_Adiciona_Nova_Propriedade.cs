using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manutec.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Adiciona_Nova_Propriedade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToleranceKm",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToleranceKm",
                table: "Vehicles");
        }
    }
}
