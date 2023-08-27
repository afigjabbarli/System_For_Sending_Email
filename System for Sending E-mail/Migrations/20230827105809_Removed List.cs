using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_for_Sending_E_mail.Migrations
{
    public partial class RemovedList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipientsList",
                table: "Emails");

            migrationBuilder.RenameColumn(
                name: "ContentJSON",
                table: "Emails",
                newName: "Content");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Emails",
                newName: "ContentJSON");

            migrationBuilder.AddColumn<List<string>>(
                name: "RecipientsList",
                table: "Emails",
                type: "text[]",
                nullable: false);
        }
    }
}
