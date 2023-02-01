using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class degafsettingiUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MahberId",
                table: "DegafiSettings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DegafiSettings_MahberId",
                table: "DegafiSettings",
                column: "MahberId");

            migrationBuilder.AddForeignKey(
                name: "FK_DegafiSettings_DefafiMahbers_MahberId",
                table: "DegafiSettings",
                column: "MahberId",
                principalTable: "DefafiMahbers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DegafiSettings_DefafiMahbers_MahberId",
                table: "DegafiSettings");

            migrationBuilder.DropIndex(
                name: "IX_DegafiSettings_MahberId",
                table: "DegafiSettings");

            migrationBuilder.DropColumn(
                name: "MahberId",
                table: "DegafiSettings");
        }
    }
}
