using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys.Locations
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(LocationDBContext dbContext) : base(dbContext)
        {
        }

        public bool IsPreExisting(string Name)
        {
            return Data.Any(location => location.Name == Name);
        }
    }
}
