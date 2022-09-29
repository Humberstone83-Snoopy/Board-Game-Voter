using BoardGameVoter.Logic.LoginManagers;
using BoardGameVoter.Logic.SessionManagers;
using BoardGameVoter.Logic.Users;
using BoardGameVoter.Services;
using BoardGameVoter.Services.DBContextService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameVoter.Pages.Shared
{
    public class BoardGameVoterPageBase : PageModel
    {
        private readonly IBGVServiceProvider __BGVServiceProvider;
        private readonly ISessionManager __SessionManager;
        private readonly ISignInManager __SignInManager;
        private readonly IUserManager __UserManager;

        public BoardGameVoterPageBase(IBGVServiceProvider bGVServiceProvider)
        {
            __BGVServiceProvider = bGVServiceProvider;
            __SessionManager = new SessionManager(bGVServiceProvider);
            __SignInManager = new SignInManager(bGVServiceProvider);
            __UserManager = new UserManager(bGVServiceProvider);
        }

        public IDBContextService DBContextService { get => __BGVServiceProvider.DBContextService; }
        public ILogger Logger { get => __BGVServiceProvider.Logger; }
        public ISessionManager SessionManager { get => __SessionManager; }
        public ISignInManager SignInManager { get => __SignInManager; }
        public IUserManager UserManager { get => __UserManager; }
    }
}
