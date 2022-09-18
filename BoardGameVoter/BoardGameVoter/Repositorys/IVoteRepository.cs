using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys
{
    public interface IVoteRepository : IRepositoryBase<Vote>
    {
        public List<Vote> GetByVoteSessionID(int voteSessionID);
    }
}
