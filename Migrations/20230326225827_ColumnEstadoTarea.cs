using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEF.Migrations
{
    /// <inheritdoc />
    public partial class ColumnEstadoTarea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Tarea",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Tarea");
        }
    }
}
