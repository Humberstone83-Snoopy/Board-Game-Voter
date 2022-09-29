using BoardGameVoter.Logic.LoginManagers;
using BoardGameVoter.Logic.Users;

namespace BoardGameVoter.Services.SignInService
{
    public class SignInService : ISignInService
    {
        public SignInService(IBGVServiceProvider bGVServiceProvider)
        {
            SignInManager = new SignInManager(bGVServiceProvider);
            UserManager = new UserManager(bGVServiceProvider);
        }

        public SignInManager SignInManager { get; set; }
        public UserManager UserManager { get; set; }
    }
}
