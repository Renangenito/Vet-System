using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetSystem.Infra.Migrations
{
    /// <inheritdoc />
    public partial class relacionamentoClienteEspecie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EspecieId",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EspecieModelId",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EspecieModelId",
                table: "Clientes",
                column: "EspecieModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Especies_EspecieModelId",
                table: "Clientes",
                column: "EspecieModelId",
                principalTable: "Especies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Especies_EspecieModelId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_EspecieModelId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "EspecieId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "EspecieModelId",
                table: "Clientes");
        }
    }
}
