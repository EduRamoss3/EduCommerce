using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class Firs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrinhos",
                columns: table => new
                {
                    IdCarrinho = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuantidadeTotal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.IdCarrinho);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    VendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.VendaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNasc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCarrinho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrinhoIdCarrinho = table.Column<string>(name: "_CarrinhoIdCarrinho", type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdPessoa);
                    table.ForeignKey(
                        name: "FK_Usuarios_Carrinhos__CarrinhoIdCarrinho",
                        column: x => x.CarrinhoIdCarrinho,
                        principalTable: "Carrinhos",
                        principalColumn: "IdCarrinho");
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Preco = table.Column<double>(type: "float", maxLength: 100000, nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipos = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", maxLength: 999, nullable: false),
                    CarrinhoIdCarrinho = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VendasVendaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_Produtos_Carrinhos_CarrinhoIdCarrinho",
                        column: x => x.CarrinhoIdCarrinho,
                        principalTable: "Carrinhos",
                        principalColumn: "IdCarrinho");
                    table.ForeignKey(
                        name: "FK_Produtos_Vendas_VendasVendaId",
                        column: x => x.VendasVendaId,
                        principalTable: "Vendas",
                        principalColumn: "VendaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CarrinhoIdCarrinho",
                table: "Produtos",
                column: "CarrinhoIdCarrinho");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_VendasVendaId",
                table: "Produtos",
                column: "VendasVendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios__CarrinhoIdCarrinho",
                table: "Usuarios",
                column: "_CarrinhoIdCarrinho");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Carrinhos");
        }
    }
}
