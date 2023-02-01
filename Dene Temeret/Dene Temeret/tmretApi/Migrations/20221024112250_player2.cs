using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class player2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CurrentTeamID",
                table: "Players",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Players",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_CurrentTeamID",
                table: "Players",
                column: "CurrentTeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_CurrentTeamID",
                table: "Players",
                column: "CurrentTeamID",
                principalTable: "Teams",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_CurrentTeamID",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_CurrentTeamID",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CurrentTeamID",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Players");
        }
    }
}
