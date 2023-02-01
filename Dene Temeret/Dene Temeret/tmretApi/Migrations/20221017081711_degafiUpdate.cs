using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class degafiUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "Degafi");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "Degafi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FromDate",
                table: "Degafi",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToDate",
                table: "Degafi",
                type: "text",
                nullable: true);
        }
    }
}
