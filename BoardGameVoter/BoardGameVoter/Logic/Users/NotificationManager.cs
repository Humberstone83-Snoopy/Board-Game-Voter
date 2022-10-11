using BoardGameVoter.Logic.Shared;
using BoardGameVoter.Models.EntityModels.Users;
using BoardGameVoter.Models.EntityModels.VoteSessions;
using BoardGameVoter.Repositorys.Users;
using BoardGameVoter.Repositorys.VoteSessions;
using BoardGameVoter.Services;

namespace BoardGameVoter.Logic.Users
{
    public class NotificationManager : BusinessBase, INotificationManager
    {
        private readonly UserNotificationRepository __UserNotificationRepository;
        private readonly UserRepository __UserRepository;
        private readonly VoteSessionRepository __VoteSessionRepository;

        public NotificationManager(IBGVServiceProvider bGVServiceProvider)
            : base(bGVServiceProvider)
        {
            __UserNotificationRepository = new UserNotificationRepository(bGVServiceProvider);
            __UserRepository = new UserRepository(bGVServiceProvider);
            __VoteSessionRepository = new VoteSessionRepository(bGVServiceProvider);
        }

        public void DeleteNotification(Guid notification_UID)
        {
            UserNotification? _Notification = __UserNotificationRepository.GetByUID(notification_UID);
            if (_Notification != null)
            {
                __UserNotificationRepository.Delete(_Notification);
            }
        }

        public void SendFriendRequestNotification(int recipientUserID, int senderUserID, Guid friendUID)
        {
            User? _Sendee = __UserRepository.GetByID(senderUserID);
            Guid _NotificationUID = Guid.NewGuid();
            __UserNotificationRepository.Add(new UserNotification()
            {
                UID = _NotificationUID,
                IsOpened = false,
                RecipientUserID = recipientUserID,
                SendeeUserID = senderUserID,
                SentDate = DateTime.Now,
                Header = "New Friend Request!",
                Message =
                $"<p>You have recieved a new friend request from {_Sendee?.UserName ?? string.Empty}</p>" +
                $"<a href=\"/friends/accept/{friendUID}/{_NotificationUID}\" class=\"btn btn-primary\">Accept</a>"
            });
        }

        public void SendVoteSessionInvite(int recipientUserID, int senderUserID, Guid voteSessionUID)
        {
            User? _Sendee = __UserRepository.GetByID(senderUserID);
            VoteSession? _VoteSession = __VoteSessionRepository.GetByUID(voteSessionUID);
            Guid _NotificationUID = Guid.NewGuid();
            __UserNotificationRepository.Add(new UserNotification()
            {
                UID = _NotificationUID,
                IsOpened = false,
                RecipientUserID = recipientUserID,
                SendeeUserID = senderUserID,
                SentDate = DateTime.Now,
                Header = "New Board Game Invite!",
                Message =
                $"<p>You have recieved a new invite from {_Sendee?.UserName ?? string.Empty}</p>" +
                $"<p>They are hosting a board gaming session on {_VoteSession?.GameDate.ToString() ?? string.Empty}, " +
                "You can manage your attendance here:<p>" +
                $"<a href=\"/lobby/accept/{voteSessionUID}/{_NotificationUID}\" class=\"btn btn-primary\">Details</a>"
            });
        }
    }
}
