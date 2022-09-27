using BoardGameVoter.Data;
using BoardGameVoter.Models;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Users;
using BoardGameVoter.Services;

namespace BoardGameVoter.Logic.LoginManagers
{
    public class SignInManager : ISignInManager
    {
        private ISessionManager __SessionManager;
        private UserRepository __UserRepository;
        private UserSessionRepository __UserSessionRepository;

        public SignInManager(UserDBContext userDBContext, UserSessionDBContext userSessionDBContext, ISessionManager sessionManager)
        {
            __UserSessionRepository = new UserSessionRepository(userSessionDBContext);
            __UserRepository = new UserRepository(userDBContext);
            __SessionManager = sessionManager;
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
