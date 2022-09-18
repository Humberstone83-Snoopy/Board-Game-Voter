using BoardGameVoter.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data.Shared
{
    public abstract class DbContextBase<T> : DbContext, IDBContextBase<T>
         where T : EntityBase
    {
        public DbContextBase(DbContextOptions options)
            : base(options)
        { }

        public DbSet<T> Data { get; set; }
    }
}