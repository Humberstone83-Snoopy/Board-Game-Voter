using BoardGameVoter.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data.Shared
{
    public interface IDBContextBase<T>
        where T : EntityBase
    {
        DbSet<T> Data { get; set; }
    }
}
