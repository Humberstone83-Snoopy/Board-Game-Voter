using BoardGameVoter.Models.EntityModels.Users;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.Users;
using BoardGameVoter.Services;

namespace BoardGameVoter.Pages.Notifications
{
    public class IndexModel : BoardGameVoterPageBase
    {
        private readonly UserNotificationRepository __UserNotificationRepository;
        private readonly UserRepository __UserRepository;

        public IndexModel(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
            __UserRepository = new UserRepository(bGVServiceProvider);
            __UserNotificationRepository = new UserNotificationRepository(bGVServiceProvider);
        }

        public void OnGet()
        {
            Notifications = __UserNotificationRepository.GetByUserID(UserManager.User.ID).OrderByDescending(notification => notification.SentDate).ToList();
            if (Notifications.Count > 0)
            {
                IEnumerable<int> _UserIDs = Notifications.Where(notification => notification.SendeeUserID > 0).Select(notification => notification.SendeeUserID ?? 0);
                Sendees = __UserRepository.GetByID(_UserIDs).ToList();
            }
        }

        public List<UserNotification> Notifications { get; set; }
        public List<User> Sendees { get; set; }
    }
}
