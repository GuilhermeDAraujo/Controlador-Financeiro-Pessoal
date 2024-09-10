using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Controlador_Financeiro_Pessoal.Migrations
{
    /// <inheritdoc />
    public partial class AddValorLancamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "DataPagamentos",
                newName: "ValorParcelado");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Lancamentos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Lancamentos");

            migrationBuilder.RenameColumn(
                name: "ValorParcelado",
                table: "DataPagamentos",
                newName: "Valor");
        }
    }
}
