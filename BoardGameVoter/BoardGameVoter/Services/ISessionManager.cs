using BoardGameVoter.Models.EntityModels;

namespace BoardGameVoter.Services
{
    public interface ISessionManager
    {
        void AddUser(User user);
        void ClearCurrentSession();
        void CreateNewSession();
        bool HandleSession(bool allowAnonymous);
        bool IsActiveSession(int userSessionID);
        void UpdateSessionInteraction();

        public User User { get; }

        public UserSession UserSession { get; }

        public int UserSessionID { get; set; }
    }
}
