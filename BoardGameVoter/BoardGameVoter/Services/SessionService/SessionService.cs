using BoardGameVoter.Logic.SessionManagers;

namespace BoardGameVoter.Services.SessionService
{
    public class SessionService : ISessionService
    {
        private readonly ISessionManager __SessionManager;

        public SessionService(IBGVServiceProvider bGVServiceProvider)
        {
            __SessionManager = new SessionManager(bGVServiceProvider);
        }

        public ISessionManager SessionManager { get => __SessionManager; }
    }
}
