using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class idupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DegafiSettings_DefafiMahbers_mahberId",
                table: "DegafiSettings");

            migrationBuilder.DropIndex(
                name: "IX_DegafiSettings_mahberId",
                table: "DegafiSettings");

            migrationBuilder.RenameColumn(
                name: "mahberId",
                table: "DegafiSettings",
                newName: "IDtemplateId");

            migrationBuilder.AddColumn<string>(
                name: "AmharicName",
                table: "DegafiSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "DegafiSettings",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmharicName",
                table: "DegafiSettings");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "DegafiSettings");

            migrationBuilder.RenameColumn(
                name: "IDtemplateId",
                table: "DegafiSettings",
                newName: "mahberId");

            migrationBuilder.CreateIndex(
                name: "IX_DegafiSettings_mahberId",
                table: "DegafiSettings",
                column: "mahberId");

            migrationBuilder.AddForeignKey(
                name: "FK_DegafiSettings_DefafiMahbers_mahberId",
                table: "DegafiSettings",
                column: "mahberId",
                principalTable: "DefafiMahbers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
