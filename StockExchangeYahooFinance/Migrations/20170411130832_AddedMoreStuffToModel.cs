using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockExchangeYahooFinance.Migrations
{
    public partial class AddedMoreStuffToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurencyId",
                table: "FinanceModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "FinanceModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rate",
                table: "FinanceModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "FinanceModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurencyId",
                table: "FinanceModel");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "FinanceModel");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "FinanceModel");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "FinanceModel");
        }
    }
}
