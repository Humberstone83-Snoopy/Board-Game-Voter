using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels.VoteSessions;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data
{
    public class VoteSessionDBContext : DbContextBase<VoteSession>
    {
        public VoteSessionDBContext(DbContextOptions<VoteSessionDBContext> options) : base(options)
        {
        }

        public DbSet<Vote> Votes { get; set; }
        public DbSet<VoteSessionAttendee> VoteSessionAttendees { get; set; }
        public DbSet<VoteSessionResult> VoteSessionResults { get; set; }
    }
}
