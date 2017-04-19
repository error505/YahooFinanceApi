using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockExchangeYahooFinance.Migrations
{
    public partial class updateExAddCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClosingTimeLocal",
                table: "Exchange",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpeningTimeLocal",
                table: "Exchange",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockExchangeId",
                table: "Exchange",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TradingDays",
                table: "Exchange",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UtcOffsetStandardTime",
                table: "Exchange",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CountryCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropColumn(
                name: "ClosingTimeLocal",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "OpeningTimeLocal",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "StockExchangeId",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "TradingDays",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "UtcOffsetStandardTime",
                table: "Exchange");
        }
    }
}
