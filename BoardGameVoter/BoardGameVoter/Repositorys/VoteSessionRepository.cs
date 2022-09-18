using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys
{
    public class VoteSessionRepository : RepositoryBase<VoteSession>, IVoteSessionRepository
    {
        public VoteSessionRepository(VoteSessionDBContext dbContext) : base(dbContext)
        {
        }

        public List<VoteSession> GetAllPublicSessions()
        {
            return GetAll().Where(session => session.IsPublic).ToList();
        }
    }
}