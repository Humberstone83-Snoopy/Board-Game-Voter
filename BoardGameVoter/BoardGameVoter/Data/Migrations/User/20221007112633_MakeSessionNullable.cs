using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameVoter.data.migrations.User
{
    /// <inheritdoc />
    public partial class MakeSessionNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_Users_FriendUserID",
                table: "UserFriends");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_Users_FriendUserID",
                table: "UserFriends",
                column: "FriendUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_Users_FriendUserID",
                table: "UserFriends");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_Users_FriendUserID",
                table: "UserFriends",
                column: "FriendUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
