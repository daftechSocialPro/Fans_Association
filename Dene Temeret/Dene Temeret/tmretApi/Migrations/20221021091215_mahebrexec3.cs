using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class mahebrexec3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MahberID",
                table: "MahberExecutives",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MahberExecutives_MahberID",
                table: "MahberExecutives",
                column: "MahberID");

            migrationBuilder.AddForeignKey(
                name: "FK_MahberExecutives_DefafiMahbers_MahberID",
                table: "MahberExecutives",
                column: "MahberID",
                principalTable: "DefafiMahbers",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MahberExecutives_DefafiMahbers_MahberID",
                table: "MahberExecutives");

            migrationBuilder.DropIndex(
                name: "IX_MahberExecutives_MahberID",
                table: "MahberExecutives");

            migrationBuilder.DropColumn(
                name: "MahberID",
                table: "MahberExecutives");
        }
    }
}
