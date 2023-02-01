using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class idupdate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdTemplates_DefafiMahbers_MahberID",
                table: "IdTemplates");

            migrationBuilder.DropIndex(
                name: "IX_IdTemplates_MahberID",
                table: "IdTemplates");

            migrationBuilder.DropColumn(
                name: "MahberID",
                table: "IdTemplates");

            migrationBuilder.DropColumn(
                name: "MahberId",
                table: "IdTemplates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MahberID",
                table: "IdTemplates",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MahberId",
                table: "IdTemplates",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdTemplates_MahberID",
                table: "IdTemplates",
                column: "MahberID");

            migrationBuilder.AddForeignKey(
                name: "FK_IdTemplates_DefafiMahbers_MahberID",
                table: "IdTemplates",
                column: "MahberID",
                principalTable: "DefafiMahbers",
                principalColumn: "ID");
        }
    }
}
