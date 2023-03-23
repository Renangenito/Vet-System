using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetSystem.Infra.Migrations
{
    /// <inheritdoc />
    public partial class medicamentosEProcedimentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Especie = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Laboratorio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procedimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Animal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Turno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Custo = table.Column<decimal>(type: "decimal(18,2)", maxLength: 100, nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EspecieId = table.Column<int>(type: "int", nullable: true),
                    EspecieModelId = table.Column<int>(type: "int", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    ClienteModelCpf = table.Column<string>(type: "nvarchar(14)", nullable: true),
                    MedicamentoId = table.Column<int>(type: "int", nullable: true),
                    MedicamentoModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Procedimentos_Clientes_ClienteModelCpf",
                        column: x => x.ClienteModelCpf,
                        principalTable: "Clientes",
                        principalColumn: "Cpf");
                    table.ForeignKey(
                        name: "FK_Procedimentos_Especies_EspecieModelId",
                        column: x => x.EspecieModelId,
                        principalTable: "Especies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Procedimentos_Medicamentos_MedicamentoModelId",
                        column: x => x.MedicamentoModelId,
                        principalTable: "Medicamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_ClienteModelCpf",
                table: "Procedimentos",
                column: "ClienteModelCpf");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_EspecieModelId",
                table: "Procedimentos",
                column: "EspecieModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_MedicamentoModelId",
                table: "Procedimentos",
                column: "MedicamentoModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Procedimentos");

            migrationBuilder.DropTable(
                name: "Medicamentos");
        }
    }
}
