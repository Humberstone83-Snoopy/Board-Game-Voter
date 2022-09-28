using BoardGameVoter.Data;
using BoardGameVoter.Data.Shared;
using BoardGameVoter.Logic.LoginManagers;
using BoardGameVoter.Logic.Users;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.Shared;

namespace BoardGameVoter.Services
{
    public class SignInService : ISignInService
    {
        public SignInService(IDBContextService dbContextService, ISessionManager sessionManager)
        {
            SignInManager = new SignInManager(dbContextService, sessionManager);
            UserManager = new UserManager(sessionManager, dbContextService);
        }

        public SignInManager SignInManager { get; set; }
        public UserManager UserManager { get; set; }
    }
}
