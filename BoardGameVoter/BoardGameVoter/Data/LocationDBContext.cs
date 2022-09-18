using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data
{
    public class LocationDBContext : DbContextBase<Location>
    {
        public LocationDBContext(DbContextOptions<LocationDBContext> options) : base(options)
        {
        }

    }
}

