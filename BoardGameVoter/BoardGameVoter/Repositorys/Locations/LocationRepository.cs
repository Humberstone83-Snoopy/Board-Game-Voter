using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.Locations
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(IDBContextService dbContextService) 
            : base(dbContextService)
        {
        }

        public bool IsPreExisting(string Name)
        {
            return Data.Any(location => location.Name == Name);
        }
    }
}
