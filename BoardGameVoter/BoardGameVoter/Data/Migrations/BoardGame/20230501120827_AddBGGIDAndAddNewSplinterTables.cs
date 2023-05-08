using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameVoter.Data.Migrations.BoardGame
{
    /// <inheritdoc />
    public partial class AddBGGIDAndAddNewSplinterTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_BoardGameTypes_BoardGameTypeID",
                table: "BoardGames");

            migrationBuilder.DropTable(
                name: "BoardGameTypes");

            migrationBuilder.DropIndex(
                name: "IX_BoardGames_BoardGameTypeID",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "BoardGameTypeID",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "Description_Long",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "Publisher",
                table: "BoardGames");

            migrationBuilder.AddColumn<int>(
                name: "BoardGameGeekID",
                table: "BoardGameCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BoardGameArtists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGameGeekID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameArtists", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BoardGameDesigners",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGameGeekID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameDesigners", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BoardGameFamilies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGameGeekID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameFamilies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BoardGameImplementations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGameGeekID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardGameID = table.Column<int>(type: "int", nullable: true),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameImplementations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BoardGameImplementations_BoardGames_BoardGameID",
                        column: x => x.BoardGameID,
                        principalTable: "BoardGames",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "BoardGamePublishers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGameGeekID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGamePublishers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BoardGame_BoardGameArtists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGameArtistID = table.Column<int>(type: "int", nullable: false),
                    BoardGameID = table.Column<int>(type: "int", nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGame_BoardGameArtists", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BoardGame_BoardGameArtists_BoardGameArtists_BoardGameArtistID",
                        column: x => x.BoardGameArtistID,
                        principalTable: "BoardGameArtists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGame_BoardGameArtists_BoardGames_BoardGameID",
                        column: x => x.BoardGameID,
                        principalTable: "BoardGames",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardGame_BoardGameDesigners",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGameDesignerID = table.Column<int>(type: "int", nullable: false),
                    BoardGameID = table.Column<int>(type: "int", nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGame_BoardGameDesigners", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BoardGame_BoardGameDesigners_BoardGameDesigners_BoardGameDesignerID",
                        column: x => x.BoardGameDesignerID,
                        principalTable: "BoardGameDesigners",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGame_BoardGameDesigners_BoardGames_BoardGameID",
                        column: x => x.BoardGameID,
                        principalTable: "BoardGames",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardGame_BoardGameFamilies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGameFamilyID = table.Column<int>(type: "int", nullable: false),
                    BoardGameID = table.Column<int>(type: "int", nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGame_BoardGameFamilies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BoardGame_BoardGameFamilies_BoardGameFamilies_BoardGameFamilyID",
                        column: x => x.BoardGameFamilyID,
                        principalTable: "BoardGameFamilies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGame_BoardGameFamilies_BoardGames_BoardGameID",
                        column: x => x.BoardGameID,
                        principalTable: "BoardGames",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardGame_BoardGamePublishers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGamePublisherID = table.Column<int>(type: "int", nullable: false),
                    BoardGameID = table.Column<int>(type: "int", nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGame_BoardGamePublishers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BoardGame_BoardGamePublishers_BoardGamePublishers_BoardGamePublisherID",
                        column: x => x.BoardGamePublisherID,
                        principalTable: "BoardGamePublishers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGame_BoardGamePublishers_BoardGames_BoardGameID",
                        column: x => x.BoardGameID,
                        principalTable: "BoardGames",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGame_BoardGameArtists_BoardGameArtistID",
                table: "BoardGame_BoardGameArtists",
                column: "BoardGameArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGame_BoardGameArtists_BoardGameID",
                table: "BoardGame_BoardGameArtists",
                column: "BoardGameID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGame_BoardGameDesigners_BoardGameDesignerID",
                table: "BoardGame_BoardGameDesigners",
                column: "BoardGameDesignerID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGame_BoardGameDesigners_BoardGameID",
                table: "BoardGame_BoardGameDesigners",
                column: "BoardGameID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGame_BoardGameFamilies_BoardGameFamilyID",
                table: "BoardGame_BoardGameFamilies",
                column: "BoardGameFamilyID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGame_BoardGameFamilies_BoardGameID",
                table: "BoardGame_BoardGameFamilies",
                column: "BoardGameID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGame_BoardGamePublishers_BoardGameID",
                table: "BoardGame_BoardGamePublishers",
                column: "BoardGameID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGame_BoardGamePublishers_BoardGamePublisherID",
                table: "BoardGame_BoardGamePublishers",
                column: "BoardGamePublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameImplementations_BoardGameID",
                table: "BoardGameImplementations",
                column: "BoardGameID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGame_BoardGameArtists");

            migrationBuilder.DropTable(
                name: "BoardGame_BoardGameDesigners");

            migrationBuilder.DropTable(
                name: "BoardGame_BoardGameFamilies");

            migrationBuilder.DropTable(
                name: "BoardGame_BoardGamePublishers");

            migrationBuilder.DropTable(
                name: "BoardGameImplementations");

            migrationBuilder.DropTable(
                name: "BoardGameArtists");

            migrationBuilder.DropTable(
                name: "BoardGameDesigners");

            migrationBuilder.DropTable(
                name: "BoardGameFamilies");

            migrationBuilder.DropTable(
                name: "BoardGamePublishers");

            migrationBuilder.DropColumn(
                name: "BoardGameGeekID",
                table: "BoardGameCategories");

            migrationBuilder.AddColumn<int>(
                name: "BoardGameTypeID",
                table: "BoardGames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_Long",
                table: "BoardGames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Publisher",
                table: "BoardGames",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "IX_BoardGames_BoardGameTypeID",
                table: "BoardGames",
                column: "BoardGameTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_BoardGameTypes_BoardGameTypeID",
                table: "BoardGames",
                column: "BoardGameTypeID",
                principalTable: "BoardGameTypes",
                principalColumn: "ID");
        }
    }
}
