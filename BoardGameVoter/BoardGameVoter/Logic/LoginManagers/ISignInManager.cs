using BoardGameVoter.Models;
using BoardGameVoter.Models.EntityModels.Users;

namespace BoardGameVoter.Logic.LoginManagers
{
    public interface ISignInManager
    {
        bool IsSignedIn();

        SignInResult PasswordSignIn(User user, string password);
        Task RefreshSignInAsync(User currentUser);
        bool SignIn(User user);
        SignInResult SignOut();
    }
}
