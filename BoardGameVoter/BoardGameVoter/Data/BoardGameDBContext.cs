using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BoardGameVoter.Data
{
    public class BoardGameDBContext : DBContextBase<BoardGame>, IDBContext
    {
        public BoardGameDBContext(DbContextOptions<BoardGameDBContext> options) : base(options)
        {
        }

        public DbSet<BoardGameArtist> ArtistData { get; set; }
        public DbSet<BoardGame_BoardGameArtist> BoardGameArtistData { get; set; }
        public DbSet<BoardGame_BoardGameCategory> BoardGameCategoryData { get; set; }
        public DbSet<BoardGame_BoardGameDesigner> BoardGameDesignerData { get; set; }
        public DbSet<BoardGame_BoardGameFamily> BoardGameFamilyData { get; set; }
        public DbSet<BoardGame_BoardGameMechanism> BoardGameMechanismData { get; set; }
        public DbSet<BoardGame_BoardGamePublisher> BoardGamePublisherData { get; set; }
        public DbSet<BoardGameCategory> CategoryData { get; set; }
        public DbSet<BoardGameDesigner> DesignerData { get; set; }
        public DbSet<BoardGameFamily> FamilyData { get; set; }
        public DbSet<BoardGameImage> ImageData { get; set; }
        public DbSet<BoardGameImplementation> ImplementationData { get; set; }
        public DbSet<BoardGameMechanism> MechanismData { get; set; }
        public DbSet<BoardGamePublisher> PublisherData { get; set; }
    }
}