using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AVista",
                table: "Produtos",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AntigoPreco",
                table: "Produtos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "DescricaoCurta",
                table: "Produtos",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "MaxVezes",
                table: "Produtos",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoSecundario",
                table: "Produtos",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AVista",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "AntigoPreco",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "DescricaoCurta",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "MaxVezes",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PrecoSecundario",
                table: "Produtos");
        }
    }
}
