using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class updateDegafi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Degafi",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressAmharic",
                table: "Degafi",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AmharicName",
                table: "Degafi",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Degafi",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Degafi");

            migrationBuilder.DropColumn(
                name: "AddressAmharic",
                table: "Degafi");

            migrationBuilder.DropColumn(
                name: "AmharicName",
                table: "Degafi");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Degafi");
        }
    }
}
