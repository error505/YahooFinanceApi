using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockExchangeYahooFinance.Migrations
{
    public partial class CompanyProfile_CompanyOfficers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndustrySimbol",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    IndustryId = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustrySimbol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndustrySimbol_Industrie_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industrie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyProfile",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Address1 = table.Column<string>(nullable: true),
                    AuditRisk = table.Column<int>(nullable: false),
                    BoardRisk = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    CompaniesId = table.Column<string>(nullable: true),
                    CompensationAsOfEpochDate = table.Column<long>(nullable: false),
                    CompensationRisk = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    FullTimeEmployees = table.Column<int>(nullable: false),
                    GovernanceEpochDate = table.Column<long>(nullable: false),
                    IndustryId = table.Column<string>(nullable: true),
                    IndustrySymbolId = table.Column<string>(nullable: true),
                    LongBusinessSummary = table.Column<string>(nullable: true),
                    OverallRisk = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    SectorId = table.Column<string>(nullable: true),
                    ShareHolderRightsRisk = table.Column<int>(nullable: false),
                    Website = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyProfile_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyProfile_Industrie_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industrie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyProfile_IndustrySimbol_IndustrySymbolId",
                        column: x => x.IndustrySymbolId,
                        principalTable: "IndustrySimbol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyProfile_Sector_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyOfficers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CompanyProfileId = table.Column<string>(nullable: true),
                    ExercisedValue = table.Column<long>(nullable: false),
                    FiscalYear = table.Column<string>(nullable: true),
                    MaxAge = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    TotalPay = table.Column<long>(nullable: false),
                    UnexercisedValue = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyOfficers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyOfficers_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyOfficers_CompanyProfile_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOfficers_CompaniesId",
                table: "CompanyOfficers",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOfficers_CompanyProfileId",
                table: "CompanyOfficers",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfile_CompaniesId",
                table: "CompanyProfile",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfile_IndustryId",
                table: "CompanyProfile",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfile_IndustrySymbolId",
                table: "CompanyProfile",
                column: "IndustrySymbolId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfile_SectorId",
                table: "CompanyProfile",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_IndustrySimbol_IndustryId",
                table: "IndustrySimbol",
                column: "IndustryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyOfficers");

            migrationBuilder.DropTable(
                name: "CompanyProfile");

            migrationBuilder.DropTable(
                name: "IndustrySimbol");
        }
    }
}
