using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class degafisettinginitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdInitial",
                table: "DegafiSettings",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdTemplates_MahberId",
                table: "IdTemplates",
                column: "MahberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DegafiSettings_IdInitial",
                table: "DegafiSettings",
                column: "IdInitial",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IdTemplates_MahberId",
                table: "IdTemplates");

            migrationBuilder.DropIndex(
                name: "IX_DegafiSettings_IdInitial",
                table: "DegafiSettings");

            migrationBuilder.DropColumn(
                name: "IdInitial",
                table: "DegafiSettings");
        }
    }
}
