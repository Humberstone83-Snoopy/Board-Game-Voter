using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.Users;

namespace BoardGameVoter.Services
{
    public class SessionManager : ISessionManager
    {
        private const string USER_SESSION_KEY_USER_ID = "UserSessionID";

        private readonly IHttpContextAccessor __ContextAccessor;
        private ILogger<BoardGameVoterPageBase> __Logger;
        private User? __User;
        private UserRepository __UserRepository;
        private UserSession? __UserSession;
        private int __UserSessionID;
        private UserSessionRepository __UserSessionRepository;

        public SessionManager(IDBContextService dbContextService, ILogger<BoardGameVoterPageBase> logger, IHttpContextAccessor accessor)
        {
            __UserSessionRepository = new UserSessionRepository(dbContextService);
            __UserRepository = new UserRepository(dbContextService);
            __Logger = logger;
            __ContextAccessor = accessor;
        }

        public void AddUser(User user)
        {
            UserSession _CurrentSession = UserSession;
            _CurrentSession.UserID = user.ID;
            _CurrentSession.LastInteraction = DateTime.Now;
            __UserSessionRepository.Update(_CurrentSession);
            __UserSession = _CurrentSession;
        }

        public void ClearCurrentSession()
        {
            __User = null;
            __UserSession = null;
            __UserSessionID = -1;
            Session.Clear();
        }

        public void CreateNewSession()
        {
            if (Session.GetInt32(USER_SESSION_KEY_USER_ID) == null)
            {
                UserSession _NewSession = new UserSession()
                {
                    UID = Guid.NewGuid(),
                    UserID = -1,
                    SessionStartTime = DateTime.Now,
                    LastInteraction = DateTime.Now
                };
                __UserSessionRepository.Add(_NewSession);
                UserSession _CurrentSession = __UserSessionRepository.GetByUID(_NewSession.UID);

                if (_CurrentSession != null)
                {
                    UserSessionID = _CurrentSession.ID;
                }
                else
                {
                    throw new Exception("Failed to Create Session");
                }
            }
            else
            {
                throw new Exception("Existing Session Detected - Cant Create New Session");
            }
        }

        public bool HandleSession(bool allowAnnoymous)
        {
            if (UserSession == null)
            {
                CreateNewSession();
            }
            if (!IsActiveSession(UserSessionID))
            {
                ClearCurrentSession();
            }
            User _CurrentUser = User;
            if ((!allowAnnoymous && _CurrentUser == null) || _CurrentUser != null)
            {
                return false;
            }
            return true;
        }

        public bool IsActiveSession(int userSessionID)
        {
            bool IsActive = false;
            UserSession _CurrentSession = __UserSessionRepository.GetByID(userSessionID);
            if (_CurrentSession != null)
            {
                IsActive = !__UserSessionRepository.IsExpiredSession(_CurrentSession);
            }
            return IsActive;
        }

        public void UpdateSessionInteraction()
        {
            UserSession _CurrentSession = UserSession;
            _CurrentSession.LastInteraction = DateTime.Now;
            __UserSessionRepository.Update(_CurrentSession);
        }

        public ISession Session { get => __ContextAccessor.HttpContext.Session; }

        public User User
        {
            get
            {
                if (__User == null && (UserSession?.UserID ?? -1) > 0)
                {
                    __User = __UserRepository.GetByID(UserSession.UserID);
                }
                return __User;
            }
        }

        public UserSession UserSession
        {
            get
            {
                if (__UserSession == null && UserSessionID > 0)
                {
                    __UserSession = __UserSessionRepository.GetByID(UserSessionID);
                }
                return __UserSession;
            }
        }

        public int UserSessionID
        {
            get
            {
                __UserSessionID = -1;
                int? SessionVariable = Session.GetInt32(USER_SESSION_KEY_USER_ID);
                if (SessionVariable != null)
                {
                    __UserSessionID = SessionVariable.Value;
                }
                return __UserSessionID;
            }

            set
            {
                if (Session.GetInt32(USER_SESSION_KEY_USER_ID) == null)
                {
                    Session.SetInt32(USER_SESSION_KEY_USER_ID, value);
                }
                __UserSessionID = Session.GetInt32(USER_SESSION_KEY_USER_ID) ?? -1;
                string userSessionID = __UserSessionID.ToString();

                __Logger.LogInformation("Session UserSessionID: {UserSessionID}", userSessionID);
            }
        }
    }
}
