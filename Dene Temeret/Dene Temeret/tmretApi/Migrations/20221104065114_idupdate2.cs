using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class idupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdTemplates",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    MahberID = table.Column<Guid>(type: "uuid", nullable: true),
                    MahberId = table.Column<string>(type: "text", nullable: true),
                    HeaderAmharic = table.Column<string>(type: "text", nullable: true),
                    HeaderEnglish = table.Column<string>(type: "text", nullable: true),
                    Subtitle1 = table.Column<string>(type: "text", nullable: true),
                    Subtitle2 = table.Column<string>(type: "text", nullable: true),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    BackgroundImage = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    AddressAmharic = table.Column<string>(type: "text", nullable: true),
                    createdBy = table.Column<Guid>(type: "uuid", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdTemplates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IdTemplates_DefafiMahbers_MahberID",
                        column: x => x.MahberID,
                        principalTable: "DefafiMahbers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DegafiSettings_IDtemplateId",
                table: "DegafiSettings",
                column: "IDtemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_IdTemplates_MahberID",
                table: "IdTemplates",
                column: "MahberID");

            migrationBuilder.AddForeignKey(
                name: "FK_DegafiSettings_IdTemplates_IDtemplateId",
                table: "DegafiSettings",
                column: "IDtemplateId",
                principalTable: "IdTemplates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DegafiSettings_IdTemplates_IDtemplateId",
                table: "DegafiSettings");

            migrationBuilder.DropTable(
                name: "IdTemplates");

            migrationBuilder.DropIndex(
                name: "IX_DegafiSettings_IDtemplateId",
                table: "DegafiSettings");
        }
    }
}
