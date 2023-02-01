using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class payment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IdGiven",
                table: "Degafi",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdGiven",
                table: "Degafi");
        }
    }
}
