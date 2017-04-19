using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockExchangeYahooFinance.Migrations
{
    public partial class updateExAddCountrya : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryId",
                table: "Exchange",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exchange_CountryId",
                table: "Exchange",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exchange_Country_CountryId",
                table: "Exchange",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exchange_Country_CountryId",
                table: "Exchange");

            migrationBuilder.DropIndex(
                name: "IX_Exchange_CountryId",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Exchange");
        }
    }
}
