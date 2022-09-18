using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameVoter.data.migrations.Vote
{
    /// <inheritdoc />
    public partial class InitialCreateVote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");
        }
    }
}
