using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data
{
    public class VoteSessionAttendeeDBContext : DbContextBase<VoteSessionAttendee>
    {
        public VoteSessionAttendeeDBContext(DbContextOptions<VoteSessionAttendeeDBContext> options) : base(options)
        {
        }
    }
}