using BoardGameVoter.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data.Shared
{
    public abstract class DBContextBase<T> : DbContext, IDBContextBase<T>
         where T : EntityBase
    {
        public DBContextBase(DbContextOptions options)
            : base(options)
        { }

        public DbSet<T> Data { get; set; }
    }
}