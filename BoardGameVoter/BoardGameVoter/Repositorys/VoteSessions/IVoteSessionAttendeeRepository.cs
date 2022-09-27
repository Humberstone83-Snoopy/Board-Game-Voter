using BoardGameVoter.Models.EntityModels.VoteSessions;

namespace BoardGameVoter.Repositorys.VoteSessions
{
    public interface IVoteSessionAttendeeRepository
    {
        public List<VoteSessionAttendee> GetByUserID(int userID);
        public List<VoteSessionAttendee> GetByVoteSessionID(int voteSessionID, bool IncludeUser = false, bool IncludeGames = false);
        public bool IsExistingAttendee(int voteSessionID, int userID);
    }
}
