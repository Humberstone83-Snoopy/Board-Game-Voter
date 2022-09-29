using BoardGameVoter.Logic.SessionManagers;

namespace BoardGameVoter.Services.SessionService
{
    public interface ISessionService
    {
        ISessionManager SessionManager { get; }
    }
}
