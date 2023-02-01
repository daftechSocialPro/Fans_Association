using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class teaminmatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                table: "MacthStats",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MacthStats_TeamId",
                table: "MacthStats",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_MacthStats_Teams_TeamId",
                table: "MacthStats",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MacthStats_Teams_TeamId",
                table: "MacthStats");

            migrationBuilder.DropIndex(
                name: "IX_MacthStats_TeamId",
                table: "MacthStats");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "MacthStats");
        }
    }
}
