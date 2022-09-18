using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data
{
    public class VoteDBContext : DbContextBase<Vote>
    {
        public VoteDBContext(DbContextOptions<VoteDBContext> options) : base(options)
        {
        }
    }
}
