using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels.BoardGames;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data
{
    public class BoardGameDBContext : DbContextBase<BoardGame>
    {
        public BoardGameDBContext(DbContextOptions<BoardGameDBContext> options) : base(options)
        {
        }

        public DbSet<BoardGameCategory> CategoryData { get; set; }
        public DbSet<BoardGameMechanism> MechanismData { get; set; }
        public DbSet<BoardGameType> TypeData { get; set; }
    }
}