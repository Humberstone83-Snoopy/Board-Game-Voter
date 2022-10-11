using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameVoter.data.migrations.user
{
    /// <inheritdoc />
    public partial class AddTimeAndHeadersToNotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "UserNotifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "SentDate",
                table: "UserNotifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Header",
                table: "UserNotifications");

            migrationBuilder.DropColumn(
                name: "SentDate",
                table: "UserNotifications");
        }
    }
}
