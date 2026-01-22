using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyModule.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "companydetail",
                columns: table => new
                {
                    companyid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    companyname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countryid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    timezone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    workrequesturl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currencyid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    taxregistrationnumber = table.Column<int>(type: "int", nullable: false),
                    language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pobox = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    billable = table.Column<bool>(type: "bit", nullable: false),
                    settings = table.Column<bool>(type: "bit", nullable: false),
                    allowworkrequest = table.Column<bool>(type: "bit", nullable: false),
                    thresholdvalue = table.Column<int>(type: "int", nullable: false),
                    vat = table.Column<int>(type: "int", nullable: true),
                    purchaserequestemail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companydetail", x => x.companyid);
                    table.ForeignKey(
                        name: "FK_companydetail_Countries_countryid",
                        column: x => x.countryid,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_companydetail_Currencies_currencyid",
                        column: x => x.currencyid,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "companyattachment",
                columns: table => new
                {
                    attachmentid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    filename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    filepath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    filetype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    companyid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyattachment", x => x.attachmentid);
                    table.ForeignKey(
                        name: "FK_companyattachment_companydetail_companyid",
                        column: x => x.companyid,
                        principalTable: "companydetail",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_companyattachment_companyid",
                table: "companyattachment",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_companydetail_countryid",
                table: "companydetail",
                column: "countryid");

            migrationBuilder.CreateIndex(
                name: "IX_companydetail_currencyid",
                table: "companydetail",
                column: "currencyid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companyattachment");

            migrationBuilder.DropTable(
                name: "companydetail");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
