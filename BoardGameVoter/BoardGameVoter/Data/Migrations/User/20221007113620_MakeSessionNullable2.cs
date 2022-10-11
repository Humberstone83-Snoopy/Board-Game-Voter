using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameVoter.data.migrations.User
{
    /// <inheritdoc />
    public partial class MakeSessionNullable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSessions_Users_UserID",
                table: "UserSessions");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "UserSessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSessions_Users_UserID",
                table: "UserSessions",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSessions_Users_UserID",
                table: "UserSessions");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "UserSessions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSessions_Users_UserID",
                table: "UserSessions",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
