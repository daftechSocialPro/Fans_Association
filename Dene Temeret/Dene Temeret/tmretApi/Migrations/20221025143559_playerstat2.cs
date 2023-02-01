using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class playerstat2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStats_Matches_MatchId",
                table: "PlayerStats");

            migrationBuilder.DropIndex(
                name: "IX_PlayerStats_MatchId",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "PlayerStats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MatchId",
                table: "PlayerStats",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStats_MatchId",
                table: "PlayerStats",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStats_Matches_MatchId",
                table: "PlayerStats",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
