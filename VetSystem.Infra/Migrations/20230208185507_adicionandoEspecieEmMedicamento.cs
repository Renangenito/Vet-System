using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetSystem.Infra.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoEspecieEmMedicamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EspecieId",
                table: "Medicamentos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EspecieModelId",
                table: "Medicamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_EspecieModelId",
                table: "Medicamentos",
                column: "EspecieModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamentos_Especies_EspecieModelId",
                table: "Medicamentos",
                column: "EspecieModelId",
                principalTable: "Especies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicamentos_Especies_EspecieModelId",
                table: "Medicamentos");

            migrationBuilder.DropIndex(
                name: "IX_Medicamentos_EspecieModelId",
                table: "Medicamentos");

            migrationBuilder.DropColumn(
                name: "EspecieId",
                table: "Medicamentos");

            migrationBuilder.DropColumn(
                name: "EspecieModelId",
                table: "Medicamentos");
        }
    }
}
