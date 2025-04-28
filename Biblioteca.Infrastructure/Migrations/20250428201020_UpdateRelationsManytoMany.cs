using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationsManytoMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Prestamos_PrestamoId",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_PrestamoId",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "PrestamoId",
                table: "Libros");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrestamoId",
                table: "Libros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_PrestamoId",
                table: "Libros",
                column: "PrestamoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Prestamos_PrestamoId",
                table: "Libros",
                column: "PrestamoId",
                principalTable: "Prestamos",
                principalColumn: "Id");
        }
    }
}
