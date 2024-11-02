using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JornadaAHP.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fontes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fontes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "NVARCHAR", nullable: true),
                    PartNumber = table.Column<string>(type: "NVARCHAR", nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    Prazo = table.Column<int>(type: "INT", nullable: false),
                    RpmMaximo = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    ForcaMaxima = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    ForcaMinima = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    FonteId = table.Column<int>(type: "int", nullable: false),
                    DriveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motores_Drives_DriveId",
                        column: x => x.DriveId,
                        principalTable: "Drives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motores_Fontes_FonteId",
                        column: x => x.FonteId,
                        principalTable: "Fontes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motores_DriveId",
                table: "Motores",
                column: "DriveId");

            migrationBuilder.CreateIndex(
                name: "IX_Motores_FonteId",
                table: "Motores",
                column: "FonteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motores");

            migrationBuilder.DropTable(
                name: "Drives");

            migrationBuilder.DropTable(
                name: "Fontes");
        }
    }
}
