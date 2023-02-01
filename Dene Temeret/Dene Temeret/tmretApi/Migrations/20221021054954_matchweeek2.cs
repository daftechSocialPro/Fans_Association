using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class matchweeek2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MatchWeek_MatchWeekId",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchWeek",
                table: "MatchWeek");

            migrationBuilder.RenameTable(
                name: "MatchWeek",
                newName: "MatchWeeks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchWeeks",
                table: "MatchWeeks",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MatchWeeks_MatchWeekId",
                table: "Matches",
                column: "MatchWeekId",
                principalTable: "MatchWeeks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MatchWeeks_MatchWeekId",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchWeeks",
                table: "MatchWeeks");

            migrationBuilder.RenameTable(
                name: "MatchWeeks",
                newName: "MatchWeek");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchWeek",
                table: "MatchWeek",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MatchWeek_MatchWeekId",
                table: "Matches",
                column: "MatchWeekId",
                principalTable: "MatchWeek",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
