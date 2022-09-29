using BoardGameVoter.Logic.LoginManagers;
using BoardGameVoter.Logic.Users;

namespace BoardGameVoter.Services.SignInService
{
    public interface ISignInService
    {
        SignInManager SignInManager { get; set; }
        UserManager UserManager { get; set; }
    }
}
