using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameVoter.Pages.Account
{
    public class LogoutModel : BoardGameVoterPageBase
    {
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(ISessionManager sessionManager, ILogger<LogoutModel> logger, ISignInService signInService)
            : base(sessionManager, logger, signInService)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            SignInManager.SignOut();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}

