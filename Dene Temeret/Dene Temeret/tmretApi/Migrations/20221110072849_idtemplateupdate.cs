using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class idtemplateupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackImage",
                table: "IdTemplates",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackImage",
                table: "IdTemplates");
        }
    }
}
