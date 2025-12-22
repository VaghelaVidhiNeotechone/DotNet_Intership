using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company_module.Migrations
{
    /// <inheritdoc />
    public partial class AddCountryCurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_companydetail_Countries_countryid",
                table: "companydetail");

            migrationBuilder.DropForeignKey(
                name: "FK_companydetail_Currencies_currencyid",
                table: "companydetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_companyattachment",
                table: "companyattachment");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "companyattachment");

            migrationBuilder.RenameColumn(
                name: "currencyid",
                table: "Currencies",
                newName: "CurrencyId");

            migrationBuilder.RenameColumn(
                name: "countryid",
                table: "Countries",
                newName: "CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "CurrencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_companyattachment",
                table: "companyattachment",
                column: "attachmentid");

            migrationBuilder.AddForeignKey(
                name: "FK_companydetail_Countries_countryid",
                table: "companydetail",
                column: "countryid",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_companydetail_Currencies_currencyid",
                table: "companydetail",
                column: "currencyid",
                principalTable: "Currencies",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_companydetail_Countries_countryid",
                table: "companydetail");

            migrationBuilder.DropForeignKey(
                name: "FK_companydetail_Currencies_currencyid",
                table: "companydetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_companyattachment",
                table: "companyattachment");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "Currencies",
                newName: "currencyid");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Countries",
                newName: "countryid");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Currencies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Countries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "companydetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "companyattachment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_companyattachment",
                table: "companyattachment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_companydetail_Countries_countryid",
                table: "companydetail",
                column: "countryid",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_companydetail_Currencies_currencyid",
                table: "companydetail",
                column: "currencyid",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
