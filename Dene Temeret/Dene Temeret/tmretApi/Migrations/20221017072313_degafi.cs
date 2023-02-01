using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class degafi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Degafi",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    MahberId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DegafiSettingId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserPhoto = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    FromDate = table.Column<string>(type: "text", nullable: true),
                    ToDate = table.Column<string>(type: "text", nullable: true),
                    InActiveDescription = table.Column<string>(type: "text", nullable: true),
                    createdBy = table.Column<Guid>(type: "uuid", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degafi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Degafi_DefafiMahbers_MahberId",
                        column: x => x.MahberId,
                        principalTable: "DefafiMahbers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Degafi_DegafiSettings_DegafiSettingId",
                        column: x => x.DegafiSettingId,
                        principalTable: "DegafiSettings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Degafi_DegafiSettingId",
                table: "Degafi",
                column: "DegafiSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_Degafi_MahberId",
                table: "Degafi",
                column: "MahberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Degafi");
        }
    }
}
