using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(LocationDBContext dbContext) : base(dbContext)
        {
        }

        public bool IsPreExisting(string Name)
        {
            return DBContext.Data.Any(location => location.Name == Name);
        }
    }
}
