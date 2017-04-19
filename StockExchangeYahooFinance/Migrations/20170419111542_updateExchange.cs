using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockExchangeYahooFinance.Migrations
{
    public partial class updateExchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataProvider",
                table: "Exchange",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delay",
                table: "Exchange",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suffix",
                table: "Exchange",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompaniesId",
                table: "FinanceModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrenciesId",
                table: "FinanceModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinanceModel_CompaniesId",
                table: "FinanceModel",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_FinanceModel_CurrenciesId",
                table: "FinanceModel",
                column: "CurrenciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinanceModel_Companies_CompaniesId",
                table: "FinanceModel",
                column: "CompaniesId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinanceModel_Currencies_CurrenciesId",
                table: "FinanceModel",
                column: "CurrenciesId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinanceModel_Companies_CompaniesId",
                table: "FinanceModel");

            migrationBuilder.DropForeignKey(
                name: "FK_FinanceModel_Currencies_CurrenciesId",
                table: "FinanceModel");

            migrationBuilder.DropIndex(
                name: "IX_FinanceModel_CompaniesId",
                table: "FinanceModel");

            migrationBuilder.DropIndex(
                name: "IX_FinanceModel_CurrenciesId",
                table: "FinanceModel");

            migrationBuilder.DropColumn(
                name: "DataProvider",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "Delay",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "Suffix",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "CompaniesId",
                table: "FinanceModel");

            migrationBuilder.DropColumn(
                name: "CurrenciesId",
                table: "FinanceModel");
        }
    }
}
