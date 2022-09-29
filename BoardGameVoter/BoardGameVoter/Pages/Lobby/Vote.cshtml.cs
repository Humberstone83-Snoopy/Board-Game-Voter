using BoardGameVoter.Logic.VoteSessions;
using BoardGameVoter.Models.EntityModels.VoteSessions;
using BoardGameVoter.Models.TableModels;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.VoteSessions;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameVoter.Pages.Lobby
{
    public class VoteModel : BoardGameVoterPageBase
    {
        private const string REDIRECT_ACTION = "REDIRECT";

        private readonly VoteManager __VoteManager;
        private readonly VoteSessionAttendeeRepository __VoteSessionAttendeeRepository;
        private readonly VoteSessionRepository __VoteSessionRepository;

        public VoteModel(IBGVServiceProvider bGVServiceProvider)

            : base(bGVServiceProvider)
        {
            __VoteManager = new VoteManager(bGVServiceProvider);
            __VoteSessionRepository = new VoteSessionRepository(bGVServiceProvider);
            __VoteSessionAttendeeRepository = new VoteSessionAttendeeRepository(bGVServiceProvider);
        }

        public IActionResult OnGet()
        {
            VoteTableModels = __VoteManager.GetVoteSessionTable(VoteSessionUID);
            TotalRowCount = VoteTableModels.Count;
            Votes = new int[TotalRowCount];
            RemainingVotes = __VoteManager.GetUserRemainingVotes(VoteSessionUID, UserManager.User.ID);

            return Page();
        }

        public IActionResult OnPost()
        {
            VoteTableModels = __VoteManager.GetVoteSessionTable(VoteSessionUID);
            RemainingVotes = __VoteManager.GetUserRemainingVotes(VoteSessionUID, UserManager.User.ID);
            if (ModelState.IsValid)
            {
                if (Votes.Sum() <= RemainingVotes)
                {
                    SaveVotes();
                    Action = REDIRECT_ACTION;
                }
                else
                {
                    ErrorMessage = $"You only have {RemainingVotes} remaining votes!";
                }
            }
            return OnGet();
        }

        private void SaveVotes()
        {
            List<Vote> _NewVotes = new();
            VoteSession _VoteSession = __VoteSessionRepository.GetByUID(VoteSessionUID);
            VoteSessionAttendee? _Attendee = __VoteSessionAttendeeRepository.GetByUserID(UserManager.User.ID).FirstOrDefault(attendee => attendee.VoteSessionID == _VoteSession.ID);
            if (_Attendee != null)
            {
                for (int voteCountIndex = 0; voteCountIndex < Votes.Length; voteCountIndex++)
                {
                    if (Votes[voteCountIndex] > 0)
                    {
                        VoteTableModel _CurrentGame = VoteTableModels[voteCountIndex];
                        _NewVotes.Add(new Vote()
                        {
                            VoteSessionAttendeeID = _Attendee.ID,
                            LibraryGameID = _CurrentGame.LibraryGameID,
                            NumberOfVotes = Votes[voteCountIndex],
                            VoteSessionID = _VoteSession.ID
                        });
                    }
                }
                __VoteManager.SaveVotes(VoteSessionUID, _Attendee, _NewVotes);
            }
        }

        public string Action { get; set; }
        public string ErrorMessage { get; set; }
        public int RemainingVotes { get; set; }
        public int TotalRowCount { get; set; }

        [BindProperty]
        public int[] Votes { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid VoteSessionUID { get; set; }

        public List<VoteTableModel> VoteTableModels { get; set; }
    }
}
