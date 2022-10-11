using BoardGameVoter.Models.EntityModels.Users;

namespace BoardGameVoter.Logic.SessionManagers
{
    public interface ISessionManager
    {
        void AddUser(User user);
        void ClearCurrentSession();
        void CreateNewSession();
        bool HandleSession(bool allowAnonymous);
        bool IsActiveSession(int userSessionID);
        void UpdateSessionInteraction();

        User User { get; }

        UserSession UserSession { get; }

        int UserSessionID { get; set; }
    }
}
