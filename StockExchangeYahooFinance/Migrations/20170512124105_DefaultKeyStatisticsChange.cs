using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockExchangeYahooFinance.Migrations
{
    public partial class DefaultKeyStatisticsChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "YtdReturn",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Yield",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TrailingEps",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TotalAssets",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ThreeYearAverageReturn",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ShortRatio",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ShortPercentOfFloat",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SharesShortPriorMonth",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SharesShort",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SharesOutstanding",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SandP52WeekChange",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "RevenueQuarterlyGrowth",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ProfitMargins",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PriceToSalesTrailing12Months",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PriceToBook",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PegRatio",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "NetIncomeToCommon",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MorningStarRiskRating",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MorningStarOverallRating",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "LastDividendValue",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "LastCapGain",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "HeldPercentInstitutions",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "HeldPercentInsiders",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ForwardPe",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ForwardEps",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "FloatShares",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "FiveYearAverageReturn",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "FiftyTwoWeekChange",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "EnterpriseValue",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "EnterpriseToRevenue",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "EnterpriseToEbitda",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "EarningsQuarterlyGrowth",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "BookValue",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Beta3Year",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Beta",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AnnualReportExpenseRatio",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AnnualHoldingsTurnover",
                table: "DefaultKeyStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "YtdReturn",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Yield",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "TrailingEps",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "TotalAssets",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "ThreeYearAverageReturn",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "ShortRatio",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "ShortPercentOfFloat",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "SharesShortPriorMonth",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "SharesShort",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "SharesOutstanding",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "SandP52WeekChange",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "RevenueQuarterlyGrowth",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "ProfitMargins",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "PriceToSalesTrailing12Months",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "PriceToBook",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "PegRatio",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "NetIncomeToCommon",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "MorningStarRiskRating",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "MorningStarOverallRating",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "LastDividendValue",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "LastCapGain",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "HeldPercentInstitutions",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "HeldPercentInsiders",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "ForwardPe",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "ForwardEps",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "FloatShares",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "FiveYearAverageReturn",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "FiftyTwoWeekChange",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "EnterpriseValue",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "EnterpriseToRevenue",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "EnterpriseToEbitda",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "EarningsQuarterlyGrowth",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "BookValue",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Beta3Year",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Beta",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "AnnualReportExpenseRatio",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "AnnualHoldingsTurnover",
                table: "DefaultKeyStatistics",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
