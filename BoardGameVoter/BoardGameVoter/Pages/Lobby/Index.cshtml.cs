using BoardGameVoter.Logic.Lobbys;
using BoardGameVoter.Models.TableModels;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;


namespace BoardGameVoter.Pages.Lobby
{
    public class IndexModel : BoardGameVoterPageBase
    {
        private readonly LobbyManager __LobbyManager;

        public IndexModel(IBGVServiceProvider bGVServiceProvider)
            : base(bGVServiceProvider)
        {
            __LobbyManager = new LobbyManager(bGVServiceProvider);
        }

        public void OnGet()
        {
            PublicLobby = __LobbyManager.GetPublicLobby();
        }

        public List<LobbyTableModel> PublicLobby { get; set; }
    }
}

