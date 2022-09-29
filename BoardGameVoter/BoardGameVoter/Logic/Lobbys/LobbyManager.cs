using BoardGameVoter.Logic.Shared;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.EntityModels.VoteSessions;
using BoardGameVoter.Models.TableModels;
using BoardGameVoter.Repositorys.Library;
using BoardGameVoter.Repositorys.Locations;
using BoardGameVoter.Repositorys.Users;
using BoardGameVoter.Repositorys.VoteSessions;
using BoardGameVoter.Services;

namespace BoardGameVoter.Logic.Lobbys
{
    public class LobbyManager : BusinessBase, ILobbyManager
    {
        private readonly LibraryGameRepository __LibraryGameRepository;
        private readonly LocationRepository __LocationRepository;
        private readonly UserRepository __UserRepository;
        private readonly VoteSessionAttendeeRepository __VoteSessionAttendeeRepository;
        private readonly VoteSessionRepository __VoteSessionRepository;

        public LobbyManager(IBGVServiceProvider bGVServiceProvider)
            : base(bGVServiceProvider)
        {
            __VoteSessionRepository = new VoteSessionRepository(bGVServiceProvider);
            __VoteSessionAttendeeRepository = new VoteSessionAttendeeRepository(bGVServiceProvider);
            __UserRepository = new UserRepository(bGVServiceProvider);
            __LocationRepository = new LocationRepository(bGVServiceProvider);
            __LibraryGameRepository = new LibraryGameRepository(bGVServiceProvider);
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
