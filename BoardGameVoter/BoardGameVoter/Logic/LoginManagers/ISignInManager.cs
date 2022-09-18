using BoardGameVoter.Models;
using BoardGameVoter.Models.EntityModels;

namespace BoardGameVoter.Logic.LoginManagers
{
    public interface ISignInManager
    {
        bool IsSignedIn();

        SignInResult PasswordSignIn(User user, string password, bool rememberMe, bool lockoutOnFailure = false);
        Task RefreshSignInAsync(User currentUser);
        bool SignIn(User user);
        SignInResult SignOut();
    }
}
