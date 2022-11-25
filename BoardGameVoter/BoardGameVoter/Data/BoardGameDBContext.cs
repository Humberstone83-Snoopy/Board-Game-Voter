using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels.BoardGames;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data
{
    public class BoardGameDBContext : DBContextBase<BoardGame>, IDBContext
    {
        public BoardGameDBContext(DbContextOptions<BoardGameDBContext> options) : base(options)
        {
        }

        public DbSet<BoardGame_BoardGameCategory> BoardGameCategoryData { get; set; }
        public DbSet<BoardGame_BoardGameMechanism> BoardGameMechanismData { get; set; }
        public DbSet<BoardGameCategory> CategoryData { get; set; }
        public DbSet<BoardGameMechanism> MechanismData { get; set; }
        public DbSet<BoardGameType> TypeData { get; set; }
        public DbSet<BoardGameImage> ImageData { get; set; }
    }
}