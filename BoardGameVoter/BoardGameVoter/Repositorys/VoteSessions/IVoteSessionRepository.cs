using BoardGameVoter.Models.EntityModels.VoteSessions;

namespace BoardGameVoter.Repositorys.VoteSessions
{
    public interface IVoteSessionRepository
    {
        public List<VoteSession> GetAllPublicSessions();
    }
}