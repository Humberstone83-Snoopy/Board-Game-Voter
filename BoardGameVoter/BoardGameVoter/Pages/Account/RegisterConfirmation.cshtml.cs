using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Pages.Account
{
    public class RegisterConfirmationModel : BoardGameVoterPageBase
    {

        public RegisterConfirmationModel(IBGVServiceProvider bGVServiceProvider)
            : base(bGVServiceProvider)
        {
        }
    }
}