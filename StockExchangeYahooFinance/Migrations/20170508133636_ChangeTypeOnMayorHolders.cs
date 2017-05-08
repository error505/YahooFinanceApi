using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockExchangeYahooFinance.Migrations
{
    public partial class ChangeTypeOnMayorHolders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "InstitutionsPercentHeld",
                table: "MajorHoldersBreakdown",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "InstitutionsFloatPercentHeld",
                table: "MajorHoldersBreakdown",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstitutionsCount",
                table: "MajorHoldersBreakdown",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "InsidersPercentHeld",
                table: "MajorHoldersBreakdown",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InstitutionsPercentHeld",
                table: "MajorHoldersBreakdown",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "InstitutionsFloatPercentHeld",
                table: "MajorHoldersBreakdown",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "InstitutionsCount",
                table: "MajorHoldersBreakdown",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "InsidersPercentHeld",
                table: "MajorHoldersBreakdown",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
