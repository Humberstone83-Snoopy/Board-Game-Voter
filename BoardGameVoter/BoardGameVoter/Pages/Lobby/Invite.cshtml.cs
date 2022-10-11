using BoardGameVoter.Logic.Users;
using BoardGameVoter.Logic.VoteSessions;
using BoardGameVoter.Models.EntityModels.Users;
using BoardGameVoter.Models.EntityModels.VoteSessions;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.Users;
using BoardGameVoter.Repositorys.VoteSessions;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameVoter.Pages.Lobby
{
    public class InviteModel : BoardGameVoterPageBase
    {
        private const string ADD_ACTION = "ADD";
        private const int STARTING_VOTE_AMOUNT = 5; // Each user gets 5 votes

        private readonly NotificationManager __NotificationManager;
        private readonly UserFriendRepository __UserFriendRepository;
        private readonly UserRepository __UserRepository;
        private readonly VoteSessionAttendeeRepository __VoteSessionAttendeeRepository;
        private readonly VoteSessionManager __VoteSessionManager;
        private readonly VoteSessionRepository __VoteSessionRepository;
        private VoteSession __VoteSession;

        public InviteModel(IBGVServiceProvider bGVServiceProvider)
            : base(bGVServiceProvider)
        {
            __NotificationManager = new NotificationManager(bGVServiceProvider);
            __UserRepository = new UserRepository(bGVServiceProvider);
            __UserFriendRepository = new UserFriendRepository(bGVServiceProvider);
            __VoteSessionRepository = new VoteSessionRepository(bGVServiceProvider);
            __VoteSessionAttendeeRepository = new VoteSessionAttendeeRepository(bGVServiceProvider);
            __VoteSessionManager = new VoteSessionManager(bGVServiceProvider);
        }

        private void AddHost(ref List<VoteSessionAttendee> attendees)
        {
            if (!attendees.Select(attendee => attendee.UserID).Contains(__VoteSession.HostUserID))
            {
                VoteSessionAttendee _Host = new()
                {
                    VoteSessionID = __VoteSession.ID,
                    UserID = __VoteSession.HostUserID,
                    VotesRemaining = STARTING_VOTE_AMOUNT
                };
                __VoteSessionAttendeeRepository.Add(_Host);
                attendees.Add(_Host);
                OpenVoting();
            }
        }

        private void HandleAction()
        {
            if (Action == ADD_ACTION)
            {
                InviteUser();
                Action = string.Empty;
                User_UID = Guid.Empty;
            }
        }

        private void InviteUser()
        {
            if (ModelState.IsValid && User_UID != Guid.Empty)
            {
                User? _SelectedAttendee = __UserRepository.GetByUID(User_UID);
                if (_SelectedAttendee == null)
                {
                    throw new ArgumentNullException(nameof(User_UID), "User Does Not Exist");
                }
                __VoteSessionManager.AddNewAttendee(_SelectedAttendee.ID, __VoteSession.ID);
                __NotificationManager.SendVoteSessionInvite(_SelectedAttendee.ID, UserManager.User.ID, VoteSessionUID);
            }
        }

        public IActionResult OnGet()
        {
            if (VoteSessionUID == Guid.Empty)
            {
                throw new ArgumentException("Must pass valid session ID", nameof(VoteSessionUID));
            }
            __VoteSession = __VoteSessionRepository.GetByUID(VoteSessionUID);
            if (__VoteSession == null)
            {
                throw new ArgumentException("Session does not exist", nameof(__VoteSession));
            }
            HandleAction();
            PopulateForm();

            return Page();
        }

        public IActionResult OnPost()
        {
            return OnGet();
        }

        private void OpenVoting()
        {
            __VoteSession.IsVotingOpen = true;
            __VoteSessionRepository.Update(__VoteSession);
        }

        private void PopulateForm()
        {
            List<VoteSessionAttendee> _ExistingAttendees = __VoteSessionAttendeeRepository.GetByVoteSessionID(__VoteSession.ID);

            AddHost(ref _ExistingAttendees);
            PopulateInvitees(_ExistingAttendees);
        }

        private void PopulateInvitees(List<VoteSessionAttendee> attendees)
        {
            InvitedUsers = new();

            IEnumerable<UserFriend> _Friends = __UserFriendRepository.GetByUserID(UserManager.User.ID).Where(friend => friend.IsAccepted);
            Friends = __UserRepository.GetByID(_Friends.Select(friend => friend.FriendUserID)).ToList();

            InvitedUsers.AddRange(__UserRepository.GetByID(attendees.Select(attendee => attendee.UserID)));

            Friends.RemoveAll(user => InvitedUsers.Contains(user));
        }

        [BindProperty]
        public string Action { get; set; }

        public List<User> Friends { get; set; }
        public List<User> InvitedUsers { get; set; }

        [BindProperty]
        public Guid User_UID { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid VoteSessionUID { get; set; }
    }
}

