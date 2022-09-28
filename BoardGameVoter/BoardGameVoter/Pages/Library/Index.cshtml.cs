using BoardGameVoter.Data;
using BoardGameVoter.Logic.UserLibrarys;
using BoardGameVoter.Models.TableModels;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Pages.Library
{
    public class IndexModel : BoardGameVoterPageBase
    {
        public const string URL = "/library/home";

        private readonly UserLibraryManager __UserLibraryManager;

        public IndexModel(ISessionManager sessionManager, ILogger<IndexModel> logger, ISignInService service,
            IDBContextService dbContextService)
            : base(sessionManager, logger, service)
        {
            __UserLibraryManager = new UserLibraryManager(dbContextService);
        }

        public void OnGet()
        {
            UserLibrary = __UserLibraryManager.GetUserLibrary(UserManager.User.ID);
        }

        public List<UserLibraryTableModel> UserLibrary { get; set; }
    }
}
