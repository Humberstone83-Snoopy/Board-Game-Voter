using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Pages.Account
{
    public class ResetPasswordConfirmationModel : BoardGameVoterPageBase
    {
        public ResetPasswordConfirmationModel(ISessionManager sessionManager, ILogger<ResetPasswordConfirmationModel> logger, ISignInService signInService)
            : base(sessionManager, logger, signInService)
        {
        }
    }
}
