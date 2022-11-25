using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameVoter.Data.Migrations.BoardGame
{
    /// <inheritdoc />
    public partial class FixTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGameCategoryData_BoardGameCategories_BoardGameCategoryID",
                table: "BoardGameCategoryData");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGameCategoryData_BoardGames_BoardGameID",
                table: "BoardGameCategoryData");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGameMechanismData_BoardGameMechanisms_BoardGameMechanismID",
                table: "BoardGameMechanismData");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGameMechanismData_BoardGames_BoardGameID",
                table: "BoardGameMechanismData");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageData_BoardGames_BoardGameID",
                table: "ImageData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageData",
                table: "ImageData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardGameMechanismData",
                table: "BoardGameMechanismData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardGameCategoryData",
                table: "BoardGameCategoryData");

            migrationBuilder.RenameTable(
                name: "ImageData",
                newName: "BoardGameImages");

            migrationBuilder.RenameTable(
                name: "BoardGameMechanismData",
                newName: "BoardGame_BoardGameMechanisms");

            migrationBuilder.RenameTable(
                name: "BoardGameCategoryData",
                newName: "BoardGame_BoardGameCategories");

            migrationBuilder.RenameIndex(
                name: "IX_ImageData_BoardGameID",
                table: "BoardGameImages",
                newName: "IX_BoardGameImages_BoardGameID");

            migrationBuilder.RenameIndex(
                name: "IX_BoardGameMechanismData_BoardGameMechanismID",
                table: "BoardGame_BoardGameMechanisms",
                newName: "IX_BoardGame_BoardGameMechanisms_BoardGameMechanismID");

            migrationBuilder.RenameIndex(
                name: "IX_BoardGameMechanismData_BoardGameID",
                table: "BoardGame_BoardGameMechanisms",
                newName: "IX_BoardGame_BoardGameMechanisms_BoardGameID");

            migrationBuilder.RenameIndex(
                name: "IX_BoardGameCategoryData_BoardGameID",
                table: "BoardGame_BoardGameCategories",
                newName: "IX_BoardGame_BoardGameCategories_BoardGameID");

            migrationBuilder.RenameIndex(
                name: "IX_BoardGameCategoryData_BoardGameCategoryID",
                table: "BoardGame_BoardGameCategories",
                newName: "IX_BoardGame_BoardGameCategories_BoardGameCategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardGameImages",
                table: "BoardGameImages",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardGame_BoardGameMechanisms",
                table: "BoardGame_BoardGameMechanisms",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardGame_BoardGameCategories",
                table: "BoardGame_BoardGameCategories",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGame_BoardGameCategories_BoardGameCategories_BoardGameCategoryID",
                table: "BoardGame_BoardGameCategories",
                column: "BoardGameCategoryID",
                principalTable: "BoardGameCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGame_BoardGameCategories_BoardGames_BoardGameID",
                table: "BoardGame_BoardGameCategories",
                column: "BoardGameID",
                principalTable: "BoardGames",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGame_BoardGameMechanisms_BoardGameMechanisms_BoardGameMechanismID",
                table: "BoardGame_BoardGameMechanisms",
                column: "BoardGameMechanismID",
                principalTable: "BoardGameMechanisms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGame_BoardGameMechanisms_BoardGames_BoardGameID",
                table: "BoardGame_BoardGameMechanisms",
                column: "BoardGameID",
                principalTable: "BoardGames",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGameImages_BoardGames_BoardGameID",
                table: "BoardGameImages",
                column: "BoardGameID",
                principalTable: "BoardGames",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGame_BoardGameCategories_BoardGameCategories_BoardGameCategoryID",
                table: "BoardGame_BoardGameCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGame_BoardGameCategories_BoardGames_BoardGameID",
                table: "BoardGame_BoardGameCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGame_BoardGameMechanisms_BoardGameMechanisms_BoardGameMechanismID",
                table: "BoardGame_BoardGameMechanisms");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGame_BoardGameMechanisms_BoardGames_BoardGameID",
                table: "BoardGame_BoardGameMechanisms");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGameImages_BoardGames_BoardGameID",
                table: "BoardGameImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardGameImages",
                table: "BoardGameImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardGame_BoardGameMechanisms",
                table: "BoardGame_BoardGameMechanisms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardGame_BoardGameCategories",
                table: "BoardGame_BoardGameCategories");

            migrationBuilder.RenameTable(
                name: "BoardGameImages",
                newName: "ImageData");

            migrationBuilder.RenameTable(
                name: "BoardGame_BoardGameMechanisms",
                newName: "BoardGameMechanismData");

            migrationBuilder.RenameTable(
                name: "BoardGame_BoardGameCategories",
                newName: "BoardGameCategoryData");

            migrationBuilder.RenameIndex(
                name: "IX_BoardGameImages_BoardGameID",
                table: "ImageData",
                newName: "IX_ImageData_BoardGameID");

            migrationBuilder.RenameIndex(
                name: "IX_BoardGame_BoardGameMechanisms_BoardGameMechanismID",
                table: "BoardGameMechanismData",
                newName: "IX_BoardGameMechanismData_BoardGameMechanismID");

            migrationBuilder.RenameIndex(
                name: "IX_BoardGame_BoardGameMechanisms_BoardGameID",
                table: "BoardGameMechanismData",
                newName: "IX_BoardGameMechanismData_BoardGameID");

            migrationBuilder.RenameIndex(
                name: "IX_BoardGame_BoardGameCategories_BoardGameID",
                table: "BoardGameCategoryData",
                newName: "IX_BoardGameCategoryData_BoardGameID");

            migrationBuilder.RenameIndex(
                name: "IX_BoardGame_BoardGameCategories_BoardGameCategoryID",
                table: "BoardGameCategoryData",
                newName: "IX_BoardGameCategoryData_BoardGameCategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageData",
                table: "ImageData",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardGameMechanismData",
                table: "BoardGameMechanismData",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardGameCategoryData",
                table: "BoardGameCategoryData",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGameCategoryData_BoardGameCategories_BoardGameCategoryID",
                table: "BoardGameCategoryData",
                column: "BoardGameCategoryID",
                principalTable: "BoardGameCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGameCategoryData_BoardGames_BoardGameID",
                table: "BoardGameCategoryData",
                column: "BoardGameID",
                principalTable: "BoardGames",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGameMechanismData_BoardGameMechanisms_BoardGameMechanismID",
                table: "BoardGameMechanismData",
                column: "BoardGameMechanismID",
                principalTable: "BoardGameMechanisms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGameMechanismData_BoardGames_BoardGameID",
                table: "BoardGameMechanismData",
                column: "BoardGameID",
                principalTable: "BoardGames",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageData_BoardGames_BoardGameID",
                table: "ImageData",
                column: "BoardGameID",
                principalTable: "BoardGames",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
