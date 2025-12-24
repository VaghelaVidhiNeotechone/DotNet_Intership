using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company_module.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCompanyDetailColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "companydetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "allowworkrequest",
                table: "companydetail",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "billable",
                table: "companydetail",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "companydetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "countryid",
                table: "companydetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "currencyid",
                table: "companydetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "isdeleted",
                table: "companydetail",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "language",
                table: "companydetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "phonenumber",
                table: "companydetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "pobox",
                table: "companydetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "purchaserequestemail",
                table: "companydetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "settings",
                table: "companydetail",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "companydetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "taxregistrationnumber",
                table: "companydetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "thresholdvalue",
                table: "companydetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "timezone",
                table: "companydetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "vat",
                table: "companydetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "workrequesturl",
                table: "companydetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "allowworkrequest",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "billable",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "city",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "countryid",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "currencyid",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "isdeleted",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "language",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "phonenumber",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "pobox",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "purchaserequestemail",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "settings",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "status",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "taxregistrationnumber",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "thresholdvalue",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "timezone",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "vat",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "workrequesturl",
                table: "companydetail");
        }
    }
}
