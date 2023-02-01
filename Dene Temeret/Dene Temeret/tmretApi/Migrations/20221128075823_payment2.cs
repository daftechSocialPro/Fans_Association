using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmretApi.Migrations
{
    public partial class payment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoneyRemaining",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "DegafiSettings",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "DegafiSettings",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "paymentStyle",
                table: "DegafiSettings",
                newName: "IncreasesEvery");

            migrationBuilder.RenameColumn(
                name: "money",
                table: "DegafiSettings",
                newName: "PenalityAmount");

            migrationBuilder.AddColumn<bool>(
                name: "HasPenality",
                table: "DegafiSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "MultiplyAmount",
                table: "DegafiSettings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Payment",
                table: "DegafiSettings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "AdPhoto",
                table: "Advertisements",
                type: "text",
                nullable: true,
                oldClrType: typeof(string[]),
                oldType: "text[]",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasPenality",
                table: "DegafiSettings");

            migrationBuilder.DropColumn(
                name: "MultiplyAmount",
                table: "DegafiSettings");

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "DegafiSettings");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DegafiSettings",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "DegafiSettings",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "PenalityAmount",
                table: "DegafiSettings",
                newName: "money");

            migrationBuilder.RenameColumn(
                name: "IncreasesEvery",
                table: "DegafiSettings",
                newName: "paymentStyle");

            migrationBuilder.AddColumn<float>(
                name: "MoneyRemaining",
                table: "Payments",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string[]>(
                name: "AdPhoto",
                table: "Advertisements",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
