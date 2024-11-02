using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JornadaAHP.Migrations
{
    /// <inheritdoc />
    public partial class alteradoCaterogia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Motores",
                type: "NVARCHAR",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "ForcaMedia",
                table: "Motores",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForcaMedia",
                table: "Motores");

            migrationBuilder.AlterColumn<int>(
                name: "Categoria",
                table: "Motores",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR");
        }
    }
}
