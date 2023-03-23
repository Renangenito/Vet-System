using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetSystem.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ajustandoMaiusculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sexo",
                table: "Especies",
                newName: "Sexo");

            migrationBuilder.RenameColumn(
                name: "pesoKg",
                table: "Especies",
                newName: "PesoKg");

            migrationBuilder.RenameColumn(
                name: "cor",
                table: "Especies",
                newName: "Cor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sexo",
                table: "Especies",
                newName: "sexo");

            migrationBuilder.RenameColumn(
                name: "PesoKg",
                table: "Especies",
                newName: "pesoKg");

            migrationBuilder.RenameColumn(
                name: "Cor",
                table: "Especies",
                newName: "cor");
        }
    }
}
