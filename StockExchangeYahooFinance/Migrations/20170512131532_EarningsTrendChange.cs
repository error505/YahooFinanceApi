using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockExchangeYahooFinance.Migrations
{
    public partial class EarningsTrendChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EarningsEstimate_EarningsTrend_EarningsTrendId",
                table: "EarningsEstimate");

            migrationBuilder.DropForeignKey(
                name: "FK_EpsRevisions_EarningsTrend_EarningsTrendId",
                table: "EpsRevisions");

            migrationBuilder.DropForeignKey(
                name: "FK_EpsTrend_EarningsTrend_EarningsTrendId",
                table: "EpsTrend");

            migrationBuilder.DropForeignKey(
                name: "FK_RevenueEstimate_EarningsTrend_EarningsTrendId",
                table: "RevenueEstimate");

            migrationBuilder.DropIndex(
                name: "IX_RevenueEstimate_EarningsTrendId",
                table: "RevenueEstimate");

            migrationBuilder.DropIndex(
                name: "IX_EpsTrend_EarningsTrendId",
                table: "EpsTrend");

            migrationBuilder.DropIndex(
                name: "IX_EpsRevisions_EarningsTrendId",
                table: "EpsRevisions");

            migrationBuilder.DropIndex(
                name: "IX_EarningsEstimate_EarningsTrendId",
                table: "EarningsEstimate");

            migrationBuilder.DropColumn(
                name: "EarningsTrendId",
                table: "RevenueEstimate");

            migrationBuilder.DropColumn(
                name: "EarningsTrendId",
                table: "EpsTrend");

            migrationBuilder.DropColumn(
                name: "EarningsTrendId",
                table: "EpsRevisions");

            migrationBuilder.DropColumn(
                name: "EarningsTrendId",
                table: "EarningsEstimate");

            migrationBuilder.RenameColumn(
                name: "EarningsEstimate",
                table: "EarningsTrend",
                newName: "RevenueEstimateId");

            migrationBuilder.AlterColumn<double>(
                name: "Growth",
                table: "EarningsTrend",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RevenueEstimateId",
                table: "EarningsTrend",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EarningsEstimateId",
                table: "EarningsTrend",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EpsRevisionsId",
                table: "EarningsTrend",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EpsTrendId",
                table: "EarningsTrend",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "YearAgoEps",
                table: "EarningsEstimate",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Low",
                table: "EarningsEstimate",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "High",
                table: "EarningsEstimate",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Growth",
                table: "EarningsEstimate",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Avg",
                table: "EarningsEstimate",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NumberOfAnalysts",
                table: "EarningsEstimate",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_EarningsTrend_EarningsEstimateId",
                table: "EarningsTrend",
                column: "EarningsEstimateId");

            migrationBuilder.CreateIndex(
                name: "IX_EarningsTrend_EpsRevisionsId",
                table: "EarningsTrend",
                column: "EpsRevisionsId");

            migrationBuilder.CreateIndex(
                name: "IX_EarningsTrend_EpsTrendId",
                table: "EarningsTrend",
                column: "EpsTrendId");

            migrationBuilder.CreateIndex(
                name: "IX_EarningsTrend_RevenueEstimateId",
                table: "EarningsTrend",
                column: "RevenueEstimateId");

            migrationBuilder.AddForeignKey(
                name: "FK_EarningsTrend_EarningsEstimate_EarningsEstimateId",
                table: "EarningsTrend",
                column: "EarningsEstimateId",
                principalTable: "EarningsEstimate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EarningsTrend_EpsRevisions_EpsRevisionsId",
                table: "EarningsTrend",
                column: "EpsRevisionsId",
                principalTable: "EpsRevisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EarningsTrend_EpsTrend_EpsTrendId",
                table: "EarningsTrend",
                column: "EpsTrendId",
                principalTable: "EpsTrend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EarningsTrend_RevenueEstimate_RevenueEstimateId",
                table: "EarningsTrend",
                column: "RevenueEstimateId",
                principalTable: "RevenueEstimate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EarningsTrend_EarningsEstimate_EarningsEstimateId",
                table: "EarningsTrend");

            migrationBuilder.DropForeignKey(
                name: "FK_EarningsTrend_EpsRevisions_EpsRevisionsId",
                table: "EarningsTrend");

            migrationBuilder.DropForeignKey(
                name: "FK_EarningsTrend_EpsTrend_EpsTrendId",
                table: "EarningsTrend");

            migrationBuilder.DropForeignKey(
                name: "FK_EarningsTrend_RevenueEstimate_RevenueEstimateId",
                table: "EarningsTrend");

            migrationBuilder.DropIndex(
                name: "IX_EarningsTrend_EarningsEstimateId",
                table: "EarningsTrend");

            migrationBuilder.DropIndex(
                name: "IX_EarningsTrend_EpsRevisionsId",
                table: "EarningsTrend");

            migrationBuilder.DropIndex(
                name: "IX_EarningsTrend_EpsTrendId",
                table: "EarningsTrend");

            migrationBuilder.DropIndex(
                name: "IX_EarningsTrend_RevenueEstimateId",
                table: "EarningsTrend");

            migrationBuilder.DropColumn(
                name: "EarningsEstimateId",
                table: "EarningsTrend");

            migrationBuilder.DropColumn(
                name: "EpsRevisionsId",
                table: "EarningsTrend");

            migrationBuilder.DropColumn(
                name: "EpsTrendId",
                table: "EarningsTrend");

            migrationBuilder.DropColumn(
                name: "NumberOfAnalysts",
                table: "EarningsEstimate");

            migrationBuilder.RenameColumn(
                name: "RevenueEstimateId",
                table: "EarningsTrend",
                newName: "EarningsEstimate");

            migrationBuilder.AddColumn<string>(
                name: "EarningsTrendId",
                table: "RevenueEstimate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EarningsTrendId",
                table: "EpsTrend",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EarningsTrendId",
                table: "EpsRevisions",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Growth",
                table: "EarningsTrend",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "EarningsEstimate",
                table: "EarningsTrend",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "YearAgoEps",
                table: "EarningsEstimate",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Low",
                table: "EarningsEstimate",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "High",
                table: "EarningsEstimate",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Growth",
                table: "EarningsEstimate",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Avg",
                table: "EarningsEstimate",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "EarningsTrendId",
                table: "EarningsEstimate",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RevenueEstimate_EarningsTrendId",
                table: "RevenueEstimate",
                column: "EarningsTrendId");

            migrationBuilder.CreateIndex(
                name: "IX_EpsTrend_EarningsTrendId",
                table: "EpsTrend",
                column: "EarningsTrendId");

            migrationBuilder.CreateIndex(
                name: "IX_EpsRevisions_EarningsTrendId",
                table: "EpsRevisions",
                column: "EarningsTrendId");

            migrationBuilder.CreateIndex(
                name: "IX_EarningsEstimate_EarningsTrendId",
                table: "EarningsEstimate",
                column: "EarningsTrendId");

            migrationBuilder.AddForeignKey(
                name: "FK_EarningsEstimate_EarningsTrend_EarningsTrendId",
                table: "EarningsEstimate",
                column: "EarningsTrendId",
                principalTable: "EarningsTrend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EpsRevisions_EarningsTrend_EarningsTrendId",
                table: "EpsRevisions",
                column: "EarningsTrendId",
                principalTable: "EarningsTrend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EpsTrend_EarningsTrend_EarningsTrendId",
                table: "EpsTrend",
                column: "EarningsTrendId",
                principalTable: "EarningsTrend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RevenueEstimate_EarningsTrend_EarningsTrendId",
                table: "RevenueEstimate",
                column: "EarningsTrendId",
                principalTable: "EarningsTrend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
