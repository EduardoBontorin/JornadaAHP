using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JornadaAHP.Migrations
{
    /// <inheritdoc />
    public partial class RemovidoForcaMinima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForcaMinima",
                table: "Motores");

            migrationBuilder.AddColumn<int>(
                name: "RpmMedio",
                table: "Motores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RpmMedio",
                table: "Motores");

            migrationBuilder.AddColumn<decimal>(
                name: "ForcaMinima",
                table: "Motores",
                type: "DECIMAL(18,0)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
