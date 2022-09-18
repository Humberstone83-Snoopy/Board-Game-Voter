using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys
{
    public interface IVoteSessionAttendeeRepository : IRepositoryBase<VoteSessionAttendee>
    {
        public List<VoteSessionAttendee> GetByUserID(int userID);
        public List<VoteSessionAttendee> GetByVoteSessionID(int voteSessionID, bool IncludeUser = false, bool IncludeGames = false);
        public bool IsExistingAttendee(int voteSessionID, int userID);
    }
}
