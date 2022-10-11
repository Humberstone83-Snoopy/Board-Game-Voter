using BoardGameVoter.Logic.Users;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameVoter.Pages.Notifications
{
    public class DeleteModel : BoardGameVoterPageBase
    {
        private readonly NotificationManager __NotificationManager;

        public DeleteModel(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {

            __NotificationManager = new NotificationManager(bGVServiceProvider);
        }

        public void OnGet()
        {
            __NotificationManager.DeleteNotification(NotificationUID);
            Response.Redirect("/notifications");
        }

        [BindProperty(SupportsGet = true)]
        public Guid NotificationUID { get; set; } = Guid.Empty;
    }
}
