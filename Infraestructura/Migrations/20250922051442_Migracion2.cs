using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class Migracion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "editorial_id",
                table: "libros");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "editorial_id",
                table: "libros",
                type: "int",
                nullable: true);
        }
    }
}
