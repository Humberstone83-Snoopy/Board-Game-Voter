using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Pages.Account
{
    public class ForgotPasswordConfirmationModel : BoardGameVoterPageBase
    {
        public ForgotPasswordConfirmationModel(ISessionManager sessionManager, ILogger<ForgotPasswordConfirmationModel> logger, ISignInService signInService)
            : base(sessionManager, logger, signInService)
        {
        }
    }
}
