using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.Enums;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoardGameVoter.Pages.Library
{
    public class UpdateModel : BoardGameVoterPageBase
    {
        private const string DELETE_ACTION = "DELETE";
        private const string REDIRECT_ACTION = "REDIRECT";
        private const string SAVE_ACTION = "SAVE";

        private readonly BoardGameRepository __BoardGameRepository;
        private readonly LibraryGameRepository __LibraryGameRepository;

        public UpdateModel(ISessionManager sessionManager, ILogger<UpdateModel> logger, ISignInService service, LibraryGameDBContext libraryGameDBContext, BoardGameDBContext boardGameDBContext)
            : base(sessionManager, logger, service)
        {
            __BoardGameRepository = new BoardGameRepository(boardGameDBContext);
            __LibraryGameRepository = new LibraryGameRepository(libraryGameDBContext);
        }

        private void Delete()
        {
            __LibraryGameRepository.Delete(LibraryGame);
            Action = REDIRECT_ACTION;
        }

        private void FetchData()
        {
            LibraryGame = __LibraryGameRepository.GetByUID(LibraryUID);
            if (LibraryGame != null)
            {
                BoardGame = __BoardGameRepository.GetByID(LibraryGame.BoardGameID);
                if (BoardGame == null)
                {
                    throw new ArgumentNullException("Board Game not found", nameof(BoardGame));
                }
            }
            else
            {
                throw new ArgumentNullException("Library Game not found", nameof(LibraryGame));
            }

        }

        private void HandleAction()
        {
            switch (Action)
            {
                case SAVE_ACTION:
                    Update();
                    Action = string.Empty;
                    break;
                case DELETE_ACTION:
                    Delete();
                    break;
            }
        }

        public IActionResult OnGet()
        {
            if (LibraryUID == Guid.Empty)
            {
                throw new ArgumentException("No UID Passed", nameof(LibraryUID));
            }
            FetchData();
            HandleAction();
            PopulateForm();
            return Page();
        }

        public IActionResult OnPost()
        {
            return OnGet();
        }

        private void PopulateForm()
        {
            Nickname = LibraryGame.Name;
            Title = BoardGame.Title;
            Description = BoardGame.Description;
            LearningDifficulty = BoardGame.LearningDifficulty;
            MaximumPlayers = BoardGame.MaximumPlayers;
            MinimumPlayers = BoardGame.MinimumPlayers;
            MaxPlayTime = BoardGame.MaxPlayTime;
            MinimumPlayTime = BoardGame.MinimumPlayTime;
            Publisher = BoardGame.Publisher;
            IsActive = LibraryGame.IsAvailable;
        }

        private void Update()
        {
            if (ModelState.IsValid)
            {
                if (BoardGame.LearningDifficulty != LearningDifficulty)
                {
                    BoardGame.LearningDifficulty = LearningDifficulty;
                    __BoardGameRepository.Update(BoardGame);
                }
                LibraryGame.Name = Nickname;
                LibraryGame.IsAvailable = IsActive;
                __LibraryGameRepository.Update(LibraryGame);
            }
        }

        [BindProperty]
        public string Action { get; set; }

        private BoardGame BoardGame { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [BindProperty]
        public bool DisableInputs { get; set; } = true;

        [BindProperty]
        [Required]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Difficulty")]
        public Difficulty LearningDifficulty { get; set; }

        public LibraryGame LibraryGame { get; private set; }

        [BindProperty(SupportsGet = true)]
        public Guid LibraryUID { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Maximum Players")]
        public int MaximumPlayers { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Maximum Play Time")]
        public int MaxPlayTime { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Minimum Players")]
        public int MinimumPlayers { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Minimum Play Time")]
        public int MinimumPlayTime { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nickname")]
        public string Nickname { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Publisher")]
        public string Publisher { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Title")]
        public string Title { get; set; }
    }
}