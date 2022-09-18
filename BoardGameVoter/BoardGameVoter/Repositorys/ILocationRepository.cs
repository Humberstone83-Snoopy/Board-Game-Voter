using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys
{
    public interface ILocationRepository : IRepositoryBase<Location>
    {
        public bool IsPreExisting(string Name);
    }
}
