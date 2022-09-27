using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.EntityModels.VoteSessions;
using BoardGameVoter.Models.TableModels;
using BoardGameVoter.Repositorys.Library;
using BoardGameVoter.Repositorys.Locations;
using BoardGameVoter.Repositorys.Users;
using BoardGameVoter.Repositorys.VoteSessions;

namespace BoardGameVoter.Logic.Lobbys
{
    public class LobbyManager : ILobbyManager
    {
        private LibraryGameRepository __LibraryGameRepository;
        private LocationRepository __LocationRepository;
        private UserRepository __UserRepository;
        private VoteSessionAttendeeRepository __VoteSessionAttendeeRepository;
        private VoteSessionRepository __VoteSessionRepository;

        public LobbyManager(VoteSessionDBContext voteSessionDBContext, UserDBContext userDBContext,
            LibraryGameDBContext libraryGameDbContext, LocationDBContext locationDBContext)
        {
            __VoteSessionRepository = new VoteSessionRepository(voteSessionDBContext);
            __VoteSessionAttendeeRepository = new VoteSessionAttendeeRepository(voteSessionDBContext);
            __UserRepository = new UserRepository(userDBContext);
            __LocationRepository = new LocationRepository(locationDBContext);
            __LibraryGameRepository = new LibraryGameRepository(libraryGameDbContext);
        }

        public List<LobbyTableModel> GetPublicLobby()
        {
            List<LobbyTableModel> _PublicLobby = new();

            List<VoteSession> _Sessions = __VoteSessionRepository.GetAllPublicSessions();
            List<VoteSessionAttendee> _Attendees = __VoteSessionAttendeeRepository.GetAll().ToList();
            List<User> _Users = __UserRepository.GetAll().ToList();
            List<Location> _Locations = __LocationRepository.GetAll().ToList();
            List<LibraryGame> _LibraryGames = __LibraryGameRepository.GetAll().ToList();

            foreach (VoteSession session in _Sessions)
            {
                _PublicLobby.Add(new LobbyTableModel()
                {
                    VoteSession = session,
                    Host = _Users.FirstOrDefault(user => user.ID == session.HostUserID),
                    Location = _Locations.FirstOrDefault(location => location.ID == session.LocationID),
                    WinningGame = _LibraryGames.FirstOrDefault(game => game.ID == session.LeadGameID),
                    Attendees = _Attendees.Where(attendee => attendee.VoteSessionID == session.ID).ToList()
                });
            }

            return _PublicLobby;
        }
    }
}
