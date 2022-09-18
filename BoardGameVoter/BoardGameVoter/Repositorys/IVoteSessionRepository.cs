using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys
{
    public interface IVoteSessionRepository : IRepositoryBase<VoteSession>
    {
        public List<VoteSession> GetAllPublicSessions();
    }
}