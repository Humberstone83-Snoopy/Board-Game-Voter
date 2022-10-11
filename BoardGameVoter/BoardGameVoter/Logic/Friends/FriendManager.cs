using BoardGameVoter.Logic.Shared;
using BoardGameVoter.Logic.Users;
using BoardGameVoter.Models.EntityModels.Users;
using BoardGameVoter.Models.TableModels;
using BoardGameVoter.Repositorys.Library;
using BoardGameVoter.Repositorys.Users;
using BoardGameVoter.Services;

namespace BoardGameVoter.Logic.Friends
{
    public class FriendManager : BusinessBase
    {
        private readonly LibraryGameRepository __LibraryGameRepository;
        private readonly NotificationManager __NotificationManager;
        private readonly UserFriendRepository __UserFriendRepository;
        private readonly UserRepository __UserRepository;

        public FriendManager(IBGVServiceProvider bGVServiceProvider)
            : base(bGVServiceProvider)
        {
            __UserRepository = new UserRepository(bGVServiceProvider);
            __UserFriendRepository = new UserFriendRepository(bGVServiceProvider);
            __NotificationManager = new NotificationManager(bGVServiceProvider);
            __LibraryGameRepository = new LibraryGameRepository(bGVServiceProvider);
        }

        public void AcceptRequest(Guid friend_UID)
        {
            UserFriend? _RequestEntity = __UserFriendRepository.GetByUID(friend_UID);
            if (_RequestEntity != null && !_RequestEntity.IsAccepted)
            {
                _RequestEntity.IsAccepted = true;
                __UserFriendRepository.Update(_RequestEntity);
                if (!IsExistingFriend(_RequestEntity.FriendUserID, _RequestEntity.UserID))
                {
                    __UserFriendRepository.Add(new UserFriend()
                    {
                        UserID = _RequestEntity.FriendUserID,
                        FriendUserID = _RequestEntity.UserID,
                        IsAccepted = true
                    });
                }
                else
                {
                    UserFriend _FriendEntity = __UserFriendRepository.GetByFriendsUserID(_RequestEntity.FriendUserID, _RequestEntity.UserID);
                    _FriendEntity.IsAccepted = true;
                    __UserFriendRepository.Update(_FriendEntity);
                }
            }
        }

        private List<FriendsTableModel> ConvertUserToFriendsTableModels(List<User> Users)
        {
            List<FriendsTableModel> _TableModels = new();

            foreach (User _Friend in Users)
            {
                _TableModels.Add(new FriendsTableModel()
                {
                    FirstName = _Friend.FirstName,
                    LastName = _Friend.LastName,
                    Username = _Friend.UserName,
                    TotalGames = CountGames(_Friend),
                    Online = _Friend.IsActive,
                    UID = _Friend.UID
                });
            }
            return _TableModels;
        }

        private int CountGames(User user)
        {
            return __LibraryGameRepository.GetByUserID(user.ID).Count;
        }

        public List<FriendsTableModel> GetFriendsTable(int userID)
        {
            IEnumerable<UserFriend> _Friends = __UserFriendRepository.GetByUserID(userID).Where(friend => friend.IsAccepted);
            return ConvertUserToFriendsTableModels(__UserRepository.GetByID(_Friends.Select(friend => friend.FriendUserID)).ToList());
        }

        private bool IsExistingFriend(int userID, int friendUserID)
        {
            return __UserFriendRepository.GetByFriendsUserID(userID, friendUserID) != null;
        }

        public void SendFriendRequest(int sender_UserID, Guid recipient_UID)
        {
            User? _Recipient = __UserRepository.GetByUID(recipient_UID);
            if (_Recipient != null && !IsExistingFriend(sender_UserID, _Recipient.ID))
            {
                UserFriend? _FriendEntity = __UserFriendRepository.Add(new UserFriend()
                {
                    IsAccepted = false,
                    FriendUserID = _Recipient.ID,
                    UserID = sender_UserID
                });
                if (_FriendEntity != null)
                {
                    __NotificationManager.SendFriendRequestNotification(_Recipient.ID, sender_UserID, _FriendEntity.UID);
                }
            }
        }

        public List<FriendsTableModel> UsernameSearch(int userID, string usernamePartial)
        {
            List<FriendsTableModel> _TableModels = new();
            IEnumerable<int> _FriendsUserIDs = __UserFriendRepository.GetByUserID(userID).Where(friend => friend.IsAccepted).Select(friend => friend.UserID);
            List<User> _Users = __UserRepository.GetAll().Where(user => !_FriendsUserIDs.Contains(user.ID) && user.ID != userID && user.UserName.Contains(usernamePartial)).ToList();
            return ConvertUserToFriendsTableModels(_Users);
        }
    }
}
