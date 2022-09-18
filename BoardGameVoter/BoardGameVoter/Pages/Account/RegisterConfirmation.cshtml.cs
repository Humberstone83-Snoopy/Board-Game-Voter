using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Pages.Account
{
    public class RegisterConfirmationModel : BoardGameVoterPageBase
    {

        public RegisterConfirmationModel(ISessionManager sessionManager, ILogger<RegisterConfirmationModel> logger, ISignInService signInService)
            : base(sessionManager, logger, signInService)
        {
        }
    }
}