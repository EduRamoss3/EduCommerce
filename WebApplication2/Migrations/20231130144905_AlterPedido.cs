using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class AlterPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pedidos_PedidoIdPedido",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_PedidoIdPedido",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PedidoIdPedido",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "QntItensPedido",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PedidoIdPedido",
                table: "ItemCarrinhos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinhos_PedidoIdPedido",
                table: "ItemCarrinhos",
                column: "PedidoIdPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCarrinhos_Pedidos_PedidoIdPedido",
                table: "ItemCarrinhos",
                column: "PedidoIdPedido",
                principalTable: "Pedidos",
                principalColumn: "IdPedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCarrinhos_Pedidos_PedidoIdPedido",
                table: "ItemCarrinhos");

            migrationBuilder.DropIndex(
                name: "IX_ItemCarrinhos_PedidoIdPedido",
                table: "ItemCarrinhos");

            migrationBuilder.DropColumn(
                name: "QntItensPedido",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PedidoIdPedido",
                table: "ItemCarrinhos");

            migrationBuilder.AddColumn<int>(
                name: "PedidoIdPedido",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_PedidoIdPedido",
                table: "Produtos",
                column: "PedidoIdPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Pedidos_PedidoIdPedido",
                table: "Produtos",
                column: "PedidoIdPedido",
                principalTable: "Pedidos",
                principalColumn: "IdPedido");
        }
    }
}
