using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameVoter.Data.Migrations.VoteSession
{
    /// <inheritdoc />
    public partial class CombineVoteSessionContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChosenGameID",
                table: "VoteSessions");

            migrationBuilder.AddColumn<int>(
                name: "LeadGameID",
                table: "VoteSessions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryGameID = table.Column<int>(type: "int", nullable: false),
                    NumberOfVotes = table.Column<int>(type: "int", nullable: false),
                    VoteSessionAttendeeID = table.Column<int>(type: "int", nullable: false),
                    VoteSessionID = table.Column<int>(type: "int", nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Votes_VoteSessions_VoteSessionID",
                        column: x => x.VoteSessionID,
                        principalTable: "VoteSessions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoteSessionAttendees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    VoteSessionID = table.Column<int>(type: "int", nullable: false),
                    VotesRemaining = table.Column<int>(type: "int", nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteSessionAttendees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VoteSessionAttendees_VoteSessions_VoteSessionID",
                        column: x => x.VoteSessionID,
                        principalTable: "VoteSessions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoteSessionResults",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryGameID = table.Column<int>(type: "int", nullable: false),
                    VoteSessionID = table.Column<int>(type: "int", nullable: false),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteSessionResults", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VoteSessionResults_VoteSessions_VoteSessionID",
                        column: x => x.VoteSessionID,
                        principalTable: "VoteSessions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VoteSessionID",
                table: "Votes",
                column: "VoteSessionID");

            migrationBuilder.CreateIndex(
                name: "IX_VoteSessionAttendees_VoteSessionID",
                table: "VoteSessionAttendees",
                column: "VoteSessionID");

            migrationBuilder.CreateIndex(
                name: "IX_VoteSessionResults_VoteSessionID",
                table: "VoteSessionResults",
                column: "VoteSessionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "VoteSessionAttendees");

            migrationBuilder.DropTable(
                name: "VoteSessionResults");

            migrationBuilder.DropColumn(
                name: "LeadGameID",
                table: "VoteSessions");

            migrationBuilder.AddColumn<int>(
                name: "ChosenGameID",
                table: "VoteSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
