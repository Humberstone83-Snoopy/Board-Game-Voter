using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.EntityModels.VoteSessions;
using BoardGameVoter.Models.TableModels;

namespace BoardGameVoter.Logic.VoteSessions
{
    public interface IVoteManager
    {
        public void ArchiveRemainingVotes(VoteSession voteSession);

        public int CalculateLeadingGame(VoteSession voteSession);

        public LibraryGame CreateResult(int voteSessionID, int libraryGameID);

        public int GetUserRemainingVotes(Guid voteSessionUID, int userID);

        public List<VoteTableModel> GetVoteSessionTable(Guid voteSessionUID);

        public void RefundVotes(int removedUserID, List<VoteSessionAttendee> remainingAttendees, VoteSession voteSession);

        public void SaveVotes(Guid voteSessionUID, VoteSessionAttendee attendee, List<Vote> votes);
    }
}

