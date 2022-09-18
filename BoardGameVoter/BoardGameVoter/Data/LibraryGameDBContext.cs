using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data
{
    public class LibraryGameDBContext : DbContextBase<LibraryGame>
    {
        public LibraryGameDBContext(DbContextOptions<LibraryGameDBContext> options) : base(options)
        {
        }
    }
}
