using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaWebMisRecetas.Migrations
{
    public partial class cambios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Recetas",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Recetas");
        }
    }
}
