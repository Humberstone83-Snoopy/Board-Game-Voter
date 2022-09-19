using BoardGameVoter.Data;
using BoardGameVoter.Logic.VoteSessions;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoardGameVoter.Pages.Lobby
{
    public class InviteModel : BoardGameVoterPageBase
    {
        private const string ADD_ACTION = "ADD";
        private const int STARTING_VOTE_AMOUNT = 5; // Each user gets 5 votes

        private readonly UserRepository __UserRepository;
        private readonly VoteSessionAttendeeRepository __VoteSessionAttendeeRepository;
        private readonly VoteSessionManager __VoteSessionManager;
        private readonly VoteSessionRepository __VoteSessionRepository;
        private VoteSession __VoteSession;

        public InviteModel(ISessionManager sessionManager, ILogger<InviteModel> logger, ISignInService service,
            UserDBContext userDBContext, VoteSessionDBContext voteSessionDBContext, VoteSessionAttendeeDBContext voteSessionAttendeeDBContext, VoteDBContext voteDBContext,
            VoteSessionResultDBContext voteSessionResultDBContext, LibraryGameDBContext libraryGameDbContext, BoardGameDBContext boardGameDBContext)
            : base(sessionManager, logger, service)
        {
            __UserRepository = new UserRepository(userDBContext);
            __VoteSessionRepository = new VoteSessionRepository(voteSessionDBContext);
            __VoteSessionAttendeeRepository = new VoteSessionAttendeeRepository(voteSessionAttendeeDBContext);
            __VoteSessionManager = new VoteSessionManager(voteSessionDBContext, voteSessionAttendeeDBContext,
                                    voteDBContext, voteSessionResultDBContext, userDBContext, libraryGameDbContext,
                                    boardGameDBContext);
        }

        private void HandleAction()
        {
            if (Action == ADD_ACTION)
            {
                InviteUser();
                Action = string.Empty;
            }
        }

        private void InviteUser()
        {
            if (ModelState.IsValid)
            {
                User _SelectedAttendee = __UserRepository.GetByUID(SelectedUser);
                __VoteSessionManager.AddNewAttendee(_SelectedAttendee.ID, __VoteSession.ID);
                // TODO: send notification
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
            InvitedUsers = new List<User>()
            {
            };

            List<VoteSessionAttendee> _AttendeeList = __VoteSessionAttendeeRepository.GetByVoteSessionID(__VoteSession.ID);

            if (!_AttendeeList.Select(attendee => attendee.UserID).Contains(__VoteSession.HostUserID))
            {
                VoteSessionAttendee _Host = new()
                {
                    VoteSessionID = __VoteSession.ID,
                    UserID = __VoteSession.HostUserID,
                    VotesRemaining = STARTING_VOTE_AMOUNT
                };
                __VoteSessionAttendeeRepository.Add(_Host);
                _AttendeeList.Add(_Host);
                OpenVoting();
            }

            Users = __UserRepository.GetAll();

            InvitedUsers.AddRange(Users.Where(user => _AttendeeList.Select(attendee => attendee.UserID).Contains(user.ID)));

            Users.RemoveAll(user => InvitedUsers.Contains(user));
        }

        [BindProperty]
        public string Action { get; set; }

        public List<User> InvitedUsers { get; set; }

        [BindProperty]
        [Display(Name = "User")]
        public Guid SelectedUser { get; set; }

        public List<User> Users { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid VoteSessionUID { get; set; }
    }
}

