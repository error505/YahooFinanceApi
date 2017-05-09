using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockExchangeYahooFinance.Migrations
{
    public partial class InstitutionOwnershipChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "InstitutionOwnership",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Position",
                table: "InstitutionOwnership",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PctHeld",
                table: "InstitutionOwnership",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PctHeld",
                table: "InstitutionOwnership");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "InstitutionOwnership",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "InstitutionOwnership",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
