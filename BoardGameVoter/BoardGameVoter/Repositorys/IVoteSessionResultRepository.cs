using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys
{
    public interface IVoteSessionResultRepository : IRepositoryBase<VoteSessionResult>
    {
        public List<VoteSessionResult> GetByVoteSessionID(int voteSessionID);
    }
}
