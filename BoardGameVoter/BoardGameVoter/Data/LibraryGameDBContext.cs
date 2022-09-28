using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data
{
    public class LibraryGameDBContext : DBContextBase<LibraryGame>, IDBContext
    {
        public LibraryGameDBContext(DbContextOptions<LibraryGameDBContext> options) : base(options)
        {
        }
    }
}
