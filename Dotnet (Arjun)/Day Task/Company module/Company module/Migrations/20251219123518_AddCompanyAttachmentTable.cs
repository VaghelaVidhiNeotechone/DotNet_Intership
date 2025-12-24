using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company_module.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyAttachmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companyattachment",
                columns: table => new
                {
                    attachmentid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    companyid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    filename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    filepath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    filetype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyattachment", x => x.attachmentid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companyattachment");
        }
    }
}
