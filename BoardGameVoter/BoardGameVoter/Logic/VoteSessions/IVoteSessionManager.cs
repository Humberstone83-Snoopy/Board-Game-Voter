using BoardGameVoter.Models.EntityModels;

namespace BoardGameVoter.Logic.VoteSessions
{
    public interface IVoteSessionManager
    {
        public VoteSessionAttendee AddNewAttendee(int userID, int voteSessionID);

        public void CloseVote(VoteSession voteSession);
        public void DeleteSession(VoteSession voteSession);
        public void RemoveAttendee(int userID, VoteSession voteSession);
    }
}
