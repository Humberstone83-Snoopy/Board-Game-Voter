using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Pages.Account
{
    public class LockoutModel : BoardGameVoterPageBase
    {
        public LockoutModel(IBGVServiceProvider bGVServiceProvider)
            : base(bGVServiceProvider)
        {
        }
    }
}
