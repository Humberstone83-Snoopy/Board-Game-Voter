using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Repositorys
{
    public class VoteSessionAttendeeRepository : RepositoryBase<VoteSessionAttendee>, IVoteSessionAttendeeRepository
    {
        private readonly LibraryGameRepository __LibraryGameRepository;
        private readonly UserRepository __UserRepository;

        public VoteSessionAttendeeRepository(VoteSessionAttendeeDBContext dbContext)
            : base(dbContext)
        {
        }

        public VoteSessionAttendeeRepository(VoteSessionAttendeeDBContext dbContext, UserDBContext userDBContext,
            LibraryGameDBContext libraryGameDbContext, BoardGameDBContext boardGameDBContext)
            : base(dbContext)
        {
            __UserRepository = new UserRepository(userDBContext);
            __LibraryGameRepository = new LibraryGameRepository(libraryGameDbContext, boardGameDBContext);
        }

        public List<VoteSessionAttendee> GetByUserID(int userID)
        {
            return DBContext.Data.Where(attendee => attendee.UserID == userID).ToList();
        }

        public List<VoteSessionAttendee> GetByVoteSessionID(int voteSessionID, bool IncludeUser = false, bool IncludeGames = false)
        {
            List<VoteSessionAttendee> _Attendees = DBContext.Data.Where(attendee => attendee.VoteSessionID == voteSessionID).ToList();

            if (IncludeUser && __UserRepository != null)
            {
                _Attendees = LoadWithUsers(_Attendees);
            }

            if (IncludeGames && __LibraryGameRepository != null)
            {
                _Attendees = LoadWithLibraryGames(_Attendees, true);
            }

            return _Attendees;
        }

        public bool IsExistingAttendee(int voteSessionID, int userID)
        {
            return GetByVoteSessionID(voteSessionID).Any(attendee => attendee.UserID == userID);
        }

        private List<VoteSessionAttendee> LoadWithLibraryGames(List<VoteSessionAttendee> attendees, bool IncludeBoardGames = false)
        {
            List<LibraryGame> _LibraryGames = __LibraryGameRepository.GetByUserID(attendees.Select(attendee => attendee.UserID), IncludeBoardGames);
            foreach (VoteSessionAttendee _Attendee in attendees)
            {
                _Attendee.LibraryGames = _LibraryGames.Where(game => game.UserID == _Attendee.UserID).ToList();
            }
            return attendees;
        }

        private List<VoteSessionAttendee> LoadWithUsers(List<VoteSessionAttendee> attendees)
        {
            List<User> _Users = __UserRepository.GetByID(attendees.Select(attendee => attendee.UserID));
            foreach (VoteSessionAttendee _Attendee in attendees)
            {
                _Attendee.User = _Users.FirstOrDefault(user => user.ID == _Attendee.UserID);
            }
            return attendees;
        }
    }
}
