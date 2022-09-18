using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Pages.Account
{
    public class LockoutModel : BoardGameVoterPageBase
    {
        public LockoutModel(ISessionManager sessionManager, ILogger<LockoutModel> logger, ISignInService signInService)
            : base(sessionManager, logger, signInService)
        {
        }
    }
}
