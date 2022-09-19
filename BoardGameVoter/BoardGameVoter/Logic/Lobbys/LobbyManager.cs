using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.TableModels;
using BoardGameVoter.Repositorys;

namespace BoardGameVoter.Logic.Lobbys
{
    public class LobbyManager : ILobbyManager
    {
        private VoteSessionRepository __VoteSessionRepository;
        private VoteSessionAttendeeRepository __VoteSessionAttendeeRepository;
        private UserRepository __UserRepository;
        private LocationRepository __LocationRepository;
        private LibraryGameRepository __LibraryGameRepository;

        public LobbyManager(VoteSessionDBContext voteSessionDBContext,
            VoteSessionAttendeeDBContext voteSessionAttendeeDBContext, UserDBContext userDBContext,
            LibraryGameDBContext libraryGameDbContext, LocationDBContext locationDBContext)
        {
            __VoteSessionRepository = new VoteSessionRepository(voteSessionDBContext);
            __VoteSessionAttendeeRepository = new VoteSessionAttendeeRepository(voteSessionAttendeeDBContext);
            __UserRepository = new UserRepository(userDBContext);
            __LocationRepository = new LocationRepository(locationDBContext);
            __LibraryGameRepository = new LibraryGameRepository(libraryGameDbContext);
        }

        public List<LobbyTableModel> GetPublicLobby()
        {
            List<LobbyTableModel> _PublicLobby = new();

            List<VoteSession> _Sessions = __VoteSessionRepository.GetAllPublicSessions();
            List<VoteSessionAttendee> _Attendees = __VoteSessionAttendeeRepository.GetAll();
            List<User> _Users = __UserRepository.GetAll();
            List<Location> _Locations = __LocationRepository.GetAll();
            List<LibraryGame> _LibraryGames = __LibraryGameRepository.GetAll();

            foreach (VoteSession session in _Sessions)
            {
                _PublicLobby.Add(new LobbyTableModel()
                {
                    VoteSession = session,
                    Host = _Users.FirstOrDefault(user => user.ID == session.HostUserID),
                    Location = _Locations.FirstOrDefault(location => location.ID == session.LocationID),
                    WinningGame = _LibraryGames.FirstOrDefault(game => game.ID == session.ChosenGameID),
                    Attendees = _Attendees.Where(attendee => attendee.VoteSessionID == session.ID).ToList()
                });
            }

            return _PublicLobby;
        }
    }
}
