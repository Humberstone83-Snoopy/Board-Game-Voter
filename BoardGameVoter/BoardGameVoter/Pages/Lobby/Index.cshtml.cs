using BoardGameVoter.Data;
using BoardGameVoter.Logic.Lobbys;
using BoardGameVoter.Models.TableModels;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Pages.Lobby
{
    public class IndexModel : BoardGameVoterPageBase
    {
        private readonly LobbyManager __LobbyManager;

        public IndexModel(ISessionManager sessionManager, ILogger<IndexModel> logger, ISignInService service,
            VoteSessionDBContext voteSessionDBContext, UserDBContext userDBContext, 
            LibraryGameDBContext libraryGameDBContext, LocationDBContext locationDBContext)
            : base(sessionManager, logger, service)
        {
            __LobbyManager = new LobbyManager(voteSessionDBContext, userDBContext, libraryGameDBContext, locationDBContext);
        }

        public void OnGet()
        {
            PublicLobby = __LobbyManager.GetPublicLobby();
        }

        public List<LobbyTableModel> PublicLobby { get; set; }
    }
}

