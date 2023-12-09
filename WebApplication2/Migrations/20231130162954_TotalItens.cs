using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class TotalItens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QntItensPedido",
                table: "Pedidos",
                newName: "TotalItensPedido");

            migrationBuilder.AddColumn<double>(
                name: "TotalPedido",
                table: "Pedidos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPedido",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "TotalItensPedido",
                table: "Pedidos",
                newName: "QntItensPedido");
        }
    }
}
