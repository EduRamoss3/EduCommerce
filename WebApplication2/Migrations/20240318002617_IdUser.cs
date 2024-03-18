using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class IdUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Id_User",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id_User",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "_ClienteIdPessoa",
                table: "Pedidos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos__ClienteIdPessoa",
                table: "Pedidos",
                column: "_ClienteIdPessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios__ClienteIdPessoa",
                table: "Pedidos",
                column: "_ClienteIdPessoa",
                principalTable: "Usuarios",
                principalColumn: "IdPessoa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios__ClienteIdPessoa",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos__ClienteIdPessoa",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Id_User",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Id_User",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "_ClienteIdPessoa",
                table: "Pedidos");
        }
    }
}
