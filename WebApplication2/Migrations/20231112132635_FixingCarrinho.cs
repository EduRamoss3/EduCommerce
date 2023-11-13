using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class FixingCarrinho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCarrinho_Carrinhos_CarrinhoIdCarrinho",
                table: "ItemCarrinho");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemCarrinho_Produtos_ProdutoIdProduto",
                table: "ItemCarrinho");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemCarrinho",
                table: "ItemCarrinho");

            migrationBuilder.RenameTable(
                name: "ItemCarrinho",
                newName: "ItemCarrinhos");

            migrationBuilder.RenameIndex(
                name: "IX_ItemCarrinho_ProdutoIdProduto",
                table: "ItemCarrinhos",
                newName: "IX_ItemCarrinhos_ProdutoIdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_ItemCarrinho_CarrinhoIdCarrinho",
                table: "ItemCarrinhos",
                newName: "IX_ItemCarrinhos_CarrinhoIdCarrinho");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemCarrinhos",
                table: "ItemCarrinhos",
                column: "IdItensCarrinho");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCarrinhos_Carrinhos_CarrinhoIdCarrinho",
                table: "ItemCarrinhos",
                column: "CarrinhoIdCarrinho",
                principalTable: "Carrinhos",
                principalColumn: "IdCarrinho");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCarrinhos_Produtos_ProdutoIdProduto",
                table: "ItemCarrinhos",
                column: "ProdutoIdProduto",
                principalTable: "Produtos",
                principalColumn: "IdProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCarrinhos_Carrinhos_CarrinhoIdCarrinho",
                table: "ItemCarrinhos");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemCarrinhos_Produtos_ProdutoIdProduto",
                table: "ItemCarrinhos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemCarrinhos",
                table: "ItemCarrinhos");

            migrationBuilder.RenameTable(
                name: "ItemCarrinhos",
                newName: "ItemCarrinho");

            migrationBuilder.RenameIndex(
                name: "IX_ItemCarrinhos_ProdutoIdProduto",
                table: "ItemCarrinho",
                newName: "IX_ItemCarrinho_ProdutoIdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_ItemCarrinhos_CarrinhoIdCarrinho",
                table: "ItemCarrinho",
                newName: "IX_ItemCarrinho_CarrinhoIdCarrinho");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemCarrinho",
                table: "ItemCarrinho",
                column: "IdItensCarrinho");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCarrinho_Carrinhos_CarrinhoIdCarrinho",
                table: "ItemCarrinho",
                column: "CarrinhoIdCarrinho",
                principalTable: "Carrinhos",
                principalColumn: "IdCarrinho");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCarrinho_Produtos_ProdutoIdProduto",
                table: "ItemCarrinho",
                column: "ProdutoIdProduto",
                principalTable: "Produtos",
                principalColumn: "IdProduto");
        }
    }
}
