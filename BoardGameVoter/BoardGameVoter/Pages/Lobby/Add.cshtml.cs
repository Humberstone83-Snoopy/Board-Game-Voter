using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.EntityModels.VoteSessions;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.Locations;
using BoardGameVoter.Repositorys.VoteSessions;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoardGameVoter.Pages.Lobby
{
    public class AddModel : BoardGameVoterPageBase
    {
        private const string COMPLETE_ACTION = "COMPLETE";

        private readonly LocationRepository __LocationRepository;
        private readonly VoteSessionRepository __VoteSessionRepository;

        public AddModel(ISessionManager sessionManager, ILogger<AddModel> logger, ISignInService service,
            IDBContextService dbContextService)
            : base(sessionManager, logger, service)
        {
            __LocationRepository = new LocationRepository(dbContextService);
            __VoteSessionRepository = new VoteSessionRepository(dbContextService);
        }

        private void Complete()
        {
            Guid _NewUID = Guid.NewGuid();
            __VoteSessionRepository.Add(new VoteSession()
            {
                LeadGameID = -1,
                GameDate = GameDate,
                LocationID = __LocationRepository.GetByUID(Location)?.ID ?? -1,
                HostUserID = UserManager.User.ID,
                IsVotingOpen = false,
                VotesCast = 0,
                IsPublic = !IsPrivate,
                UID = _NewUID,
            });
            VoteSessionUID = __VoteSessionRepository.GetByUID(_NewUID).UID;
            Action = COMPLETE_ACTION;
        }

        public IActionResult OnGet()
        {
            if (GameDate == DateTime.MinValue)
            {
                GameDate = DateTime.Now;
            }
            PopulateDropDowns();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Complete();
            }
            return OnGet();
        }

        private void PopulateDropDowns()
        {
            Locations = __LocationRepository.GetAll().ToList();
        }

        public string Action { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Game Date")]
        public DateTime GameDate { get; set; }

        [BindProperty]
        [Display(Name = "Private Session")]
        public bool IsPrivate { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Location")]
        public Guid Location { get; set; }

        public List<Location> Locations { get; set; }

        public Guid VoteSessionUID { get; set; }
    }
}

