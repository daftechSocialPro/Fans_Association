using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class ma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Players",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerID",
                table: "MacthStats",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MacthStats_PlayerID",
                table: "MacthStats",
                column: "PlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_MacthStats_Players_PlayerID",
                table: "MacthStats",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MacthStats_Players_PlayerID",
                table: "MacthStats");

            migrationBuilder.DropIndex(
                name: "IX_MacthStats_PlayerID",
                table: "MacthStats");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerID",
                table: "MacthStats");
        }
    }
}
