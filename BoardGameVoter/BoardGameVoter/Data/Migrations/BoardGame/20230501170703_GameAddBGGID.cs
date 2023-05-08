using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameVoter.Data.Migrations.BoardGame
{
    /// <inheritdoc />
    public partial class GameAddBGGID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoardGameGeekID",
                table: "BoardGames",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoardGameGeekID",
                table: "BoardGames");
        }
    }
}
