using BoardGameVoter.Logic.Friends;
using BoardGameVoter.Logic.Users;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameVoter.Pages.Friends
{
    public class AcceptModel : BoardGameVoterPageBase
    {
        private readonly FriendManager __FriendManager;
        private readonly NotificationManager __NotificationManager;

        public AcceptModel(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
            __FriendManager = new FriendManager(bGVServiceProvider);
            __NotificationManager = new NotificationManager(bGVServiceProvider);
        }

        public void OnGet()
        {
            if (Friend_UID == Guid.Empty)
            {
                throw new ArgumentException("Must pass Valid UID", nameof(Friend_UID));
            }
            __FriendManager.AcceptRequest(Friend_UID);
            __NotificationManager.DeleteNotification(Notification_UID);
            Response.Redirect("/Friends");
        }

        [BindProperty(SupportsGet = true)]
        public Guid Friend_UID { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid Notification_UID { get; set; }
    }
}
