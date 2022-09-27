using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameVoter.Data.Migrations.BoardGame
{
    /// <inheritdoc />
    public partial class ExpandBoardGameEntityWithAdditionalInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LearningDifficulty",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "MaxPlayTime",
                table: "BoardGames");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "BoardGames",
                newName: "Description_Short");

            migrationBuilder.AlterColumn<string>(
                name: "Publisher",
                table: "BoardGames",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "MinimumPlayTime",
                table: "BoardGames",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaximumPlayers",
                table: "BoardGames",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AgeRating",
                table: "BoardGames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description_Long",
                table: "BoardGames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaximumPlayTime",
                table: "BoardGames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrimaryCategoryID",
                table: "BoardGames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrimaryMechanismID",
                table: "BoardGames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrimaryTypeID",
                table: "BoardGames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "BoardGames",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "BoardGames",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryCategoryID",
                table: "BoardGames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryMechanismID",
                table: "BoardGames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryTypeID",
                table: "BoardGames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TertiaryCategoryID",
                table: "BoardGames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TertiaryMechanismID",
                table: "BoardGames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "BoardGames",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BoardGameCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BoardGameMechanisms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameMechanisms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BoardGameTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameTypes", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_PrimaryCategoryID",
                table: "BoardGames",
                column: "PrimaryCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_PrimaryMechanismID",
                table: "BoardGames",
                column: "PrimaryMechanismID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_PrimaryTypeID",
                table: "BoardGames",
                column: "PrimaryTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_SecondaryCategoryID",
                table: "BoardGames",
                column: "SecondaryCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_SecondaryMechanismID",
                table: "BoardGames",
                column: "SecondaryMechanismID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_SecondaryTypeID",
                table: "BoardGames",
                column: "SecondaryTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_TertiaryCategoryID",
                table: "BoardGames",
                column: "TertiaryCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_TertiaryMechanismID",
                table: "BoardGames",
                column: "TertiaryMechanismID");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_BoardGameCategories_PrimaryCategoryID",
                table: "BoardGames",
                column: "PrimaryCategoryID",
                principalTable: "BoardGameCategories",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_BoardGameCategories_SecondaryCategoryID",
                table: "BoardGames",
                column: "SecondaryCategoryID",
                principalTable: "BoardGameCategories",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_BoardGameCategories_TertiaryCategoryID",
                table: "BoardGames",
                column: "TertiaryCategoryID",
                principalTable: "BoardGameCategories",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_BoardGameMechanisms_PrimaryMechanismID",
                table: "BoardGames",
                column: "PrimaryMechanismID",
                principalTable: "BoardGameMechanisms",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_BoardGameMechanisms_SecondaryMechanismID",
                table: "BoardGames",
                column: "SecondaryMechanismID",
                principalTable: "BoardGameMechanisms",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_BoardGameMechanisms_TertiaryMechanismID",
                table: "BoardGames",
                column: "TertiaryMechanismID",
                principalTable: "BoardGameMechanisms",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_BoardGameTypes_PrimaryTypeID",
                table: "BoardGames",
                column: "PrimaryTypeID",
                principalTable: "BoardGameTypes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_BoardGameTypes_SecondaryTypeID",
                table: "BoardGames",
                column: "SecondaryTypeID",
                principalTable: "BoardGameTypes",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_BoardGameCategories_PrimaryCategoryID",
                table: "BoardGames");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_BoardGameCategories_SecondaryCategoryID",
                table: "BoardGames");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_BoardGameCategories_TertiaryCategoryID",
                table: "BoardGames");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_BoardGameMechanisms_PrimaryMechanismID",
                table: "BoardGames");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_BoardGameMechanisms_SecondaryMechanismID",
                table: "BoardGames");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_BoardGameMechanisms_TertiaryMechanismID",
                table: "BoardGames");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_BoardGameTypes_PrimaryTypeID",
                table: "BoardGames");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_BoardGameTypes_SecondaryTypeID",
                table: "BoardGames");

            migrationBuilder.DropTable(
                name: "BoardGameCategories");

            migrationBuilder.DropTable(
                name: "BoardGameMechanisms");

            migrationBuilder.DropTable(
                name: "BoardGameTypes");

            migrationBuilder.DropIndex(
                name: "IX_BoardGames_PrimaryCategoryID",
                table: "BoardGames");

            migrationBuilder.DropIndex(
                name: "IX_BoardGames_PrimaryMechanismID",
                table: "BoardGames");

            migrationBuilder.DropIndex(
                name: "IX_BoardGames_PrimaryTypeID",
                table: "BoardGames");

            migrationBuilder.DropIndex(
                name: "IX_BoardGames_SecondaryCategoryID",
                table: "BoardGames");

            migrationBuilder.DropIndex(
                name: "IX_BoardGames_SecondaryMechanismID",
                table: "BoardGames");

            migrationBuilder.DropIndex(
                name: "IX_BoardGames_SecondaryTypeID",
                table: "BoardGames");

            migrationBuilder.DropIndex(
                name: "IX_BoardGames_TertiaryCategoryID",
                table: "BoardGames");

            migrationBuilder.DropIndex(
                name: "IX_BoardGames_TertiaryMechanismID",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "AgeRating",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "Description_Long",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "MaximumPlayTime",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "PrimaryCategoryID",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "PrimaryMechanismID",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "PrimaryTypeID",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "SecondaryCategoryID",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "SecondaryMechanismID",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "SecondaryTypeID",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "TertiaryCategoryID",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "TertiaryMechanismID",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "BoardGames");

            migrationBuilder.RenameColumn(
                name: "Description_Short",
                table: "BoardGames",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Publisher",
                table: "BoardGames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MinimumPlayTime",
                table: "BoardGames",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaximumPlayers",
                table: "BoardGames",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LearningDifficulty",
                table: "BoardGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxPlayTime",
                table: "BoardGames",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
