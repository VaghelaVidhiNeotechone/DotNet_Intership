using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company_module.Migrations
{
    /// <inheritdoc />
    public partial class FixCountryMapping : Migration
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

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "currency");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "country");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyName",
                table: "currency",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "country",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_currency",
                table: "currency",
                column: "CurrencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_country",
                table: "country",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_companydetail_country_countryid",
                table: "companydetail",
                column: "countryid",
                principalTable: "country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_companydetail_currency_currencyid",
                table: "companydetail",
                column: "currencyid",
                principalTable: "currency",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_companydetail_country_countryid",
                table: "companydetail");

            migrationBuilder.DropForeignKey(
                name: "FK_companydetail_currency_currencyid",
                table: "companydetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_currency",
                table: "currency");

            migrationBuilder.DropPrimaryKey(
                name: "PK_country",
                table: "country");

            migrationBuilder.RenameTable(
                name: "currency",
                newName: "Currencies");

            migrationBuilder.RenameTable(
                name: "country",
                newName: "Countries");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyName",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "CurrencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "CountryId");

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
    }
}
