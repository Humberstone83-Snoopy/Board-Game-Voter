using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Pages.Account
{
    public class ResetPasswordConfirmationModel : BoardGameVoterPageBase
    {
        public ResetPasswordConfirmationModel(IBGVServiceProvider bGVServiceProvider)
            : base(bGVServiceProvider)
        {
        }
    }
}
