using BoardGameVoter.Logic.Friends;
using BoardGameVoter.Models.TableModels;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Pages.Friends
{
    public class IndexModel : BoardGameVoterPageBase
    {
        private readonly FriendManager __FriendManager;

        public IndexModel(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
            __FriendManager = new FriendManager(bGVServiceProvider);
        }

        public void OnGet()
        {
            Friends = __FriendManager.GetFriendsTable(UserManager.User.ID);
        }

        public List<FriendsTableModel> Friends { get; set; }
    }
}
