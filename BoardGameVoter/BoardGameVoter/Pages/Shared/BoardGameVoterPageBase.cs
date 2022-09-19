using BoardGameVoter.Logic.LoginManagers;
using BoardGameVoter.Logic.Users;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameVoter.Pages.Shared
{
    public class BoardGameVoterPageBase : PageModel
    {
        private readonly ISignInService __Service;
        private ISessionManager __SessionManager;

        public BoardGameVoterPageBase(ISessionManager sessionManager, ILogger<BoardGameVoterPageBase> logger, ISignInService service)
        {
            __Service = service;
            __SessionManager = sessionManager;
        }

        private ISessionManager SessionManager { get => __SessionManager; }

        public SignInManager SignInManager
        {
            get
            {
                return __Service.SignInManager;
            }
        }

        public UserManager UserManager
        {
            get
            {
                return __Service.UserManager;
            }
        }
    }
}
