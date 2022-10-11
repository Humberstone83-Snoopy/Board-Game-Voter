using BoardGameVoter.Models.EntityModels.Users;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.Users
{
    public class UserFriendRepository : RepositoryBase<UserFriend, User, RepositoryLoadOptions>, IUserFriendRepository
    {

        public UserFriendRepository(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
        }

        public UserFriend GetByFriendsUserID(int userID, int friendID)
        {
            return GetByUserID(userID).FirstOrDefault(friend => friend.FriendUserID == friendID);
        }

        public List<UserFriend> GetByUserID(int userID)
        {
            return Data.Where(friend => friend.UserID == userID).ToList();
        }
    }
}
