using BoardGameVoter.Logic.SessionManagers;
using BoardGameVoter.Logic.Shared;
using BoardGameVoter.Models;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Users;
using BoardGameVoter.Services;

namespace BoardGameVoter.Logic.LoginManagers
{
    public class SignInManager : BusinessBase, ISignInManager
    {
        private readonly ISessionManager __SessionManager;
        private readonly UserRepository __UserRepository;

        public SignInManager(IBGVServiceProvider bGVServiceProvider)
            : base(bGVServiceProvider)
        {
            __UserRepository = new UserRepository(bGVServiceProvider);
            __SessionManager = new SessionManager(bGVServiceProvider);
        }

        public bool IsSignedIn()
        {
            return __SessionManager.User != null;
        }

        public SignInResult PasswordSignIn(User user, string password, bool rememberMe, bool lockoutOnFailure = false)
        {
            SignInResult result = new();
            if (user != null && user.PasswordHash == password)
            {
                __SessionManager.AddUser(user);

                user.Logins++;
                __UserRepository.Update(user);

                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
            }
            return result;
        }

        public Task RefreshSignInAsync(User currentUser)
        {
            throw new NotImplementedException("Logic/Login/SignInManager - RefreshSignIn(User)");
        }

        public bool SignIn(User user)
        {
            __SessionManager.AddUser(user);
            return true;
        }

        public SignInResult SignOut()
        {
            __SessionManager.ClearCurrentSession();
            return new SignInResult()
            {
                Succeeded = true
            };
        }
    }
}
