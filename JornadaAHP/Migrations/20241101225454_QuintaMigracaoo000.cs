﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JornadaAHP.Migrations
{
    /// <inheritdoc />
    public partial class QuintaMigracaoo000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Motores_PartNumber",
                table: "Motores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Motores_PartNumber",
                table: "Motores",
                column: "PartNumber",
                unique: true);
        }
    }
}
