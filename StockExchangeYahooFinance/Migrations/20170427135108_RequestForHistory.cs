using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockExchangeYahooFinance.Migrations
{
    public partial class RequestForHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "AdjClose",
                table: "History",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdjClose",
                table: "History",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
