using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class CarrinhoCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Carrinhos_CarrinhoIdCarrinho",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CarrinhoIdCarrinho",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CarrinhoIdCarrinho",
                table: "Produtos");

            migrationBuilder.CreateTable(
                name: "ItemCarrinho",
                columns: table => new
                {
                    IdItensCarrinho = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProdutoIdProduto = table.Column<int>(type: "int", nullable: true),
                    QntProduto = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    IdCarrinho = table.Column<int>(type: "int", nullable: false),
                    CarrinhoIdCarrinho = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCarrinho", x => x.IdItensCarrinho);
                    table.ForeignKey(
                        name: "FK_ItemCarrinho_Carrinhos_CarrinhoIdCarrinho",
                        column: x => x.CarrinhoIdCarrinho,
                        principalTable: "Carrinhos",
                        principalColumn: "IdCarrinho");
                    table.ForeignKey(
                        name: "FK_ItemCarrinho_Produtos_ProdutoIdProduto",
                        column: x => x.ProdutoIdProduto,
                        principalTable: "Produtos",
                        principalColumn: "IdProduto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinho_CarrinhoIdCarrinho",
                table: "ItemCarrinho",
                column: "CarrinhoIdCarrinho");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinho_ProdutoIdProduto",
                table: "ItemCarrinho",
                column: "ProdutoIdProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCarrinho");

            migrationBuilder.AddColumn<string>(
                name: "CarrinhoIdCarrinho",
                table: "Produtos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CarrinhoIdCarrinho",
                table: "Produtos",
                column: "CarrinhoIdCarrinho");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Carrinhos_CarrinhoIdCarrinho",
                table: "Produtos",
                column: "CarrinhoIdCarrinho",
                principalTable: "Carrinhos",
                principalColumn: "IdCarrinho");
        }
    }
}
