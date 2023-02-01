using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class updateall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Seasons_SeasonId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "SeasonId",
                table: "Matches",
                newName: "SeasonsId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_SeasonId",
                table: "Matches",
                newName: "IX_Matches_SeasonsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Seasons_SeasonsId",
                table: "Matches",
                column: "SeasonsId",
                principalTable: "Seasons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Seasons_SeasonsId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "SeasonsId",
                table: "Matches",
                newName: "SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_SeasonsId",
                table: "Matches",
                newName: "IX_Matches_SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Seasons_SeasonId",
                table: "Matches",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
