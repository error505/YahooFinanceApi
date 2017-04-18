using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockExchangeYahooFinance.Migrations
{
    public partial class ExchangeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Exchange",
                table: "Companies",
                newName: "ExchangeId");

            migrationBuilder.AlterColumn<string>(
                name: "ExchangeId",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Exchange",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RegionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exchange_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ExchangeId",
                table: "Companies",
                column: "ExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Exchange_RegionId",
                table: "Exchange",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Exchange_ExchangeId",
                table: "Companies",
                column: "ExchangeId",
                principalTable: "Exchange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Exchange_ExchangeId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "Exchange");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ExchangeId",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "ExchangeId",
                table: "Companies",
                newName: "Exchange");

            migrationBuilder.AlterColumn<string>(
                name: "Exchange",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
