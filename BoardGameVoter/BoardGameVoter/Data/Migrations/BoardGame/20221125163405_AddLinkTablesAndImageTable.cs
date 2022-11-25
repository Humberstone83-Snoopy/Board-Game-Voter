using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameVoter.Data.Migrations.BoardGame
{
    /// <inheritdoc />
    public partial class AddLinkTablesAndImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "TertiaryMechanismID",
                table: "BoardGames",
                newName: "BoardGameTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_BoardGames_TertiaryMechanismID",
                table: "BoardGames",
                newName: "IX_BoardGames_BoardGameTypeID");

            migrationBuilder.CreateTable(
                name: "BoardGameCategoryData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGameCategoryID = table.Column<int>(type: "int", nullable: false),
                    BoardGameID = table.Column<int>(type: "int", nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameCategoryData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BoardGameCategoryData_BoardGameCategories_BoardGameCategoryID",
                        column: x => x.BoardGameCategoryID,
                        principalTable: "BoardGameCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGameCategoryData_BoardGames_BoardGameID",
                        column: x => x.BoardGameID,
                        principalTable: "BoardGames",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardGameMechanismData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGameID = table.Column<int>(type: "int", nullable: false),
                    BoardGameMechanismID = table.Column<int>(type: "int", nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameMechanismData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BoardGameMechanismData_BoardGameMechanisms_BoardGameMechanismID",
                        column: x => x.BoardGameMechanismID,
                        principalTable: "BoardGameMechanisms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGameMechanismData_BoardGames_BoardGameID",
                        column: x => x.BoardGameID,
                        principalTable: "BoardGames",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGameID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageData_BoardGames_BoardGameID",
                        column: x => x.BoardGameID,
                        principalTable: "BoardGames",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameCategoryData_BoardGameCategoryID",
                table: "BoardGameCategoryData",
                column: "BoardGameCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameCategoryData_BoardGameID",
                table: "BoardGameCategoryData",
                column: "BoardGameID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameMechanismData_BoardGameID",
                table: "BoardGameMechanismData",
                column: "BoardGameID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameMechanismData_BoardGameMechanismID",
                table: "BoardGameMechanismData",
                column: "BoardGameMechanismID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageData_BoardGameID",
                table: "ImageData",
                column: "BoardGameID");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_BoardGameTypes_BoardGameTypeID",
                table: "BoardGames",
                column: "BoardGameTypeID",
                principalTable: "BoardGameTypes",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_BoardGameTypes_BoardGameTypeID",
                table: "BoardGames");

            migrationBuilder.DropTable(
                name: "BoardGameCategoryData");

            migrationBuilder.DropTable(
                name: "BoardGameMechanismData");

            migrationBuilder.DropTable(
                name: "ImageData");

            migrationBuilder.RenameColumn(
                name: "BoardGameTypeID",
                table: "BoardGames",
                newName: "TertiaryMechanismID");

            migrationBuilder.RenameIndex(
                name: "IX_BoardGames_BoardGameTypeID",
                table: "BoardGames",
                newName: "IX_BoardGames_TertiaryMechanismID");

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
    }
}
