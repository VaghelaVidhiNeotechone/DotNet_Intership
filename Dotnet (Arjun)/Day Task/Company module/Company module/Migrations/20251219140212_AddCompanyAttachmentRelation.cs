using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company_module.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyAttachmentRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_companyattachment",
                table: "companyattachment");

            migrationBuilder.RenameColumn(
                name: "isdeleted",
                table: "companydetail",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "isdeleted",
                table: "companyattachment",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "createddate",
                table: "companyattachment",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "companydetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                name: "PK_companyattachment",
                table: "companyattachment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_companyattachment_companyid",
                table: "companyattachment",
                column: "companyid");

            migrationBuilder.AddForeignKey(
                name: "FK_companyattachment_companydetail_companyid",
                table: "companyattachment",
                column: "companyid",
                principalTable: "companydetail",
                principalColumn: "companyid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_companyattachment_companydetail_companyid",
                table: "companyattachment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_companyattachment",
                table: "companyattachment");

            migrationBuilder.DropIndex(
                name: "IX_companyattachment_companyid",
                table: "companyattachment");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "companydetail");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "companyattachment");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "companydetail",
                newName: "isdeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "companyattachment",
                newName: "isdeleted");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "companyattachment",
                newName: "createddate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_companyattachment",
                table: "companyattachment",
                column: "attachmentid");
        }
    }
}
