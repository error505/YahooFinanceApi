using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockExchangeYahooFinance.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Sector",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Region",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "IndustrySimbol",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Industrie",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "FinanceModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Exchange",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Currencies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "CompanyProfile",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "CompanyProfile",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "CompanyOfficers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "CompanyOfficers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Companies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Sector");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "IndustrySimbol");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Industrie");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "FinanceModel");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "CompanyProfile");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "CompanyProfile");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "CompanyOfficers");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "CompanyOfficers");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Companies");
        }
    }
}
