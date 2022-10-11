using BoardGameVoter.Logic.Users;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameVoter.Pages.Lobby
{
    public class AcceptModel : BoardGameVoterPageBase
    {
        private readonly NotificationManager __NotificationManager;

        public AcceptModel(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
            __NotificationManager = new NotificationManager(bGVServiceProvider);
        }

        public void OnGet()
        {
            __NotificationManager.DeleteNotification(NotificationUID);
            Response.Redirect("/lobby/details/" + VoteSessionUID);
        }

        [BindProperty(SupportsGet = true)]
        public Guid NotificationUID { get; set; } = Guid.Empty;

        [BindProperty(SupportsGet = true)]
        public Guid VoteSessionUID { get; set; }
    }
}
