using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class paymentedit5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DegafiID",
                table: "Payments",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Payments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_DegafiID",
                table: "Payments",
                column: "DegafiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Degafi_DegafiID",
                table: "Payments",
                column: "DegafiID",
                principalTable: "Degafi",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Degafi_DegafiID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_DegafiID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DegafiID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Payments");
        }
    }
}
