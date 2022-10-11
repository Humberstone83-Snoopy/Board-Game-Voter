using BoardGameVoter.Logic.Friends;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameVoter.Pages.Friends
{
    public class AddModel : BoardGameVoterPageBase
    {
        private readonly FriendManager __FriendManager;

        public AddModel(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
            __FriendManager = new FriendManager(bGVServiceProvider);
        }

        public void OnGet()
        {
            if (User_UID == Guid.Empty)
            {
                throw new ArgumentException("Must Pass Valid UID", nameof(User_UID));
            }
            __FriendManager.SendFriendRequest(UserManager.User.ID, User_UID);
            Response.Redirect("/Friends");
        }

        [BindProperty(SupportsGet = true)]
        public Guid User_UID { get; set; }
    }
}
