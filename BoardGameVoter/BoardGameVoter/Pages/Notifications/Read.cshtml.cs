using BoardGameVoter.Models.EntityModels.Users;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.Users;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameVoter.Pages.Notifications
{
    public class ReadModel : BoardGameVoterPageBase
    {
        private readonly UserNotificationRepository __UserNotificationRepository;

        public ReadModel(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
            __UserNotificationRepository = new UserNotificationRepository(bGVServiceProvider);
        }

        public void OnGet()
        {
            if (Notification_UID == Guid.Empty)
            {
                throw new ArgumentException("Must Pass Valid UID", nameof(Notification_UID));
            }

            Notification = __UserNotificationRepository.GetByUID(Notification_UID);

            if (Notification == null)
            {
                Notification = new UserNotification();
                Response.Redirect("/Notifications");
            }

            if (!(Notification?.IsOpened ?? true))
            {
                Notification.IsOpened = true;
                __UserNotificationRepository.Update(Notification);
            }
        }

        public UserNotification Notification { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid Notification_UID { get; set; }
    }
}
