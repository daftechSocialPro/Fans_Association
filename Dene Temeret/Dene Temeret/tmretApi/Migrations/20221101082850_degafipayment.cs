using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class degafipayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DegafiID",
                table: "Payments",
                type: "uuid",
                nullable: true);

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
    }
}
