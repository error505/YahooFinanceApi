using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockExchangeYahooFinance.Migrations
{
    public partial class earningsTrendRelatedObjectsChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearAgoRevenue",
                table: "RevenueEstimate");

            migrationBuilder.DropColumn(
                name: "NinetyAgoRevenue",
                table: "EpsTrend");

            migrationBuilder.RenameColumn(
                name: "ThirtydaysAgo",
                table: "EpsTrend",
                newName: "ThirtyDaysAgo");

            migrationBuilder.RenameColumn(
                name: "SixtydaysAgo",
                table: "EpsTrend",
                newName: "SixtyDaysAgo");

            migrationBuilder.AlterColumn<double>(
                name: "NumberOfAnalysts",
                table: "RevenueEstimate",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Low",
                table: "RevenueEstimate",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "High",
                table: "RevenueEstimate",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Growth",
                table: "RevenueEstimate",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Avg",
                table: "RevenueEstimate",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "YearAgoEps",
                table: "RevenueEstimate",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "ThirtyDaysAgo",
                table: "EpsTrend",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SixtyDaysAgo",
                table: "EpsTrend",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SevenDaysAgo",
                table: "EpsTrend",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Current",
                table: "EpsTrend",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NinetyDaysAgo",
                table: "EpsTrend",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "UpLast7Days",
                table: "EpsRevisions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "UpLast30Days",
                table: "EpsRevisions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "DownLast90Days",
                table: "EpsRevisions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "DownLast30Days",
                table: "EpsRevisions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearAgoEps",
                table: "RevenueEstimate");

            migrationBuilder.DropColumn(
                name: "NinetyDaysAgo",
                table: "EpsTrend");

            migrationBuilder.RenameColumn(
                name: "ThirtyDaysAgo",
                table: "EpsTrend",
                newName: "ThirtydaysAgo");

            migrationBuilder.RenameColumn(
                name: "SixtyDaysAgo",
                table: "EpsTrend",
                newName: "SixtydaysAgo");

            migrationBuilder.AlterColumn<string>(
                name: "NumberOfAnalysts",
                table: "RevenueEstimate",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Low",
                table: "RevenueEstimate",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "High",
                table: "RevenueEstimate",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Growth",
                table: "RevenueEstimate",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Avg",
                table: "RevenueEstimate",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "YearAgoRevenue",
                table: "RevenueEstimate",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThirtydaysAgo",
                table: "EpsTrend",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "SixtydaysAgo",
                table: "EpsTrend",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "SevenDaysAgo",
                table: "EpsTrend",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Current",
                table: "EpsTrend",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "NinetyAgoRevenue",
                table: "EpsTrend",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpLast7Days",
                table: "EpsRevisions",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "UpLast30Days",
                table: "EpsRevisions",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "DownLast90Days",
                table: "EpsRevisions",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "DownLast30Days",
                table: "EpsRevisions",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
