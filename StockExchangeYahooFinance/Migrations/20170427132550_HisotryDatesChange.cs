using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockExchangeYahooFinance.Migrations
{
    public partial class HisotryDatesChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "History");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "History");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "History",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "History",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "History",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "History",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
