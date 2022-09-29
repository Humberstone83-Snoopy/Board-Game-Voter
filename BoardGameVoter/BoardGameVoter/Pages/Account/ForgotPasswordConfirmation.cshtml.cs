using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Pages.Account
{
    public class ForgotPasswordConfirmationModel : BoardGameVoterPageBase
    {
        public ForgotPasswordConfirmationModel(IBGVServiceProvider bGVServiceProvider)
            : base(bGVServiceProvider)
        {
        }
    }
}
