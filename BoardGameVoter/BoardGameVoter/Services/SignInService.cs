using BoardGameVoter.Data;
using BoardGameVoter.Logic.LoginManagers;
using BoardGameVoter.Logic.Users;

namespace BoardGameVoter.Services
{
    public class SignInService : ISignInService
    {
        public SignInService(UserSessionDBContext userSessionDBContext, UserDBContext userDBContext, 
            PasswordResetTokenDBContext passwordResetTokenDBContext, EmailConfirmationTokenDBContext emailConfirmationTokenDBContext,
            ISessionManager sessionManager)
        {
            SignInManager = new SignInManager(userDBContext, userSessionDBContext, sessionManager);
            UserManager = new UserManager(sessionManager, userDBContext, passwordResetTokenDBContext, emailConfirmationTokenDBContext);
        }

        public SignInManager SignInManager { get; set; }
        public UserManager UserManager { get; set; }
    }
}
