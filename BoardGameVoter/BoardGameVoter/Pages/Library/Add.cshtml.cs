using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Models.Enums;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.BoardGames;
using BoardGameVoter.Repositorys.Library;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoardGameVoter.Pages.Library
{
    public class AddModel : BoardGameVoterPageBase
    {
        private const string AMBIGUOUS_TITLE_ERROR_MESSAGE = "Ambiguous Title - Multiple matches found";
        private const string COMPLETE_ACTION = "COMPLETE";
        private const string FIND_ACTION = "FIND";
        private const string INCOMPLETE_ERROR_MESSAGE = "Required Fields Missing - Please fill in whole form";
        private const string NONE_FOUND_ERROR_MESSAGE = "No Matches Found - Try again, or fill out manually";
        private const string REDIRECT_ACTION = "REDIRECT";

        private readonly BoardGameRepository __BoardGameRepository;
        private readonly LibraryGameRepository __LibraryGameRepository;

        public AddModel(ISessionManager sessionManager, ILogger<AddModel> logger, ISignInService service,
            IDBContextService dbContextService) 
            : base(sessionManager, logger, service)
        {
            __BoardGameRepository = new BoardGameRepository(dbContextService);
            __LibraryGameRepository = new LibraryGameRepository(dbContextService);
        }

        private void AddNewBoardGame()
        {
            BoardGame _BoardGame = new BoardGame()
            {
                Title = Title,
                Description_Short = Description,
                Weight = GameWeight,
                MaximumPlayers = MaximumPlayers,
                MaximumPlayTime = MaximumPlayTime,
                MinimumPlayers = MinimumPlayers,
                MinimumPlayTime = MinimumPlayTime,
                Publisher = Publisher,
                UID = Guid.NewGuid()
            };
            __BoardGameRepository.Add(_BoardGame);
            BoardGame = __BoardGameRepository.GetByTitle(_BoardGame.Title).FirstOrDefault();
        }

        private bool CompleteBoardGameSelection()
        {
            bool _Succesful = false;
            if (ValidateInput())
            {
                if (BoardGame == null)
                {
                    if (!FindExistingBoardGame())
                    {
                        AddNewBoardGame();
                        ErrorMessage = string.Empty;
                    }
                }
                try
                {
                    if (BoardGame != null)
                    {
                        __LibraryGameRepository.AddNew(UserManager.User, BoardGame);
                        Action = REDIRECT_ACTION;
                        _Succesful = true;
                    }
                }
                catch (ArgumentException exception)
                {
                    ErrorMessage = exception.Message;
                }
            }
            else
            {
                ErrorMessage = INCOMPLETE_ERROR_MESSAGE;
            }
            return _Succesful;
        }

        private bool FindExistingBoardGame()
        {
            bool _FoundExactMatch = false;
            if (!string.IsNullOrEmpty(Title))
            {
                List<BoardGame> _SearchResults = __BoardGameRepository.GetByTitle(Title);

                ModelState.Clear();

                if (_SearchResults.Count() > 1)
                {
                    ErrorMessage = AMBIGUOUS_TITLE_ERROR_MESSAGE;
                }
                else if (_SearchResults.Count() < 1)
                {
                    ErrorMessage = NONE_FOUND_ERROR_MESSAGE;
                }
                else
                {
                    BoardGame = _SearchResults[0];
                    _FoundExactMatch = true;

                    Title = BoardGame.Title;
                    Description = BoardGame.Description_Short;
                    GameWeight = BoardGame.Weight ?? Weight.Undefined;
                    MaximumPlayers = BoardGame.MaximumPlayers ?? MinimumPlayers;
                    MinimumPlayers = BoardGame.MinimumPlayers;
                    MaximumPlayTime = BoardGame.MaximumPlayTime ?? 0;
                    MinimumPlayTime = BoardGame.MinimumPlayTime ?? 0;
                    Publisher = BoardGame.Publisher ?? string.Empty;
                    // should not disable null fields, allow to be updated. 
                    DisableInputs = true;
                }
            }
            return _FoundExactMatch;
        }

        private bool HandleAction()
        {
            return Action switch
            {
                FIND_ACTION => FindExistingBoardGame(),
                COMPLETE_ACTION => CompleteBoardGameSelection(),
                _ => false
            };
        }

        public IActionResult OnGet()
        {
            HandleAction();
            return Page();
        }

        public IActionResult OnPost()
        {
            ErrorMessage = string.Empty;
            return OnGet();
        }

        private bool ValidateInput()
        {
            return ModelState.IsValid;
        }

        [BindProperty]
        public string Action { get; set; }

        public BoardGame BoardGame { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [BindProperty]
        public bool DisableInputs { get; set; } = false;

        public string ErrorMessage { get; private set; } = string.Empty;

        [BindProperty]
        [Required]
        [Display(Name = "Weight")]
        public Weight GameWeight { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Maximum Players")]
        public int MaximumPlayers { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Maximum Play Time")]
        public int MaximumPlayTime { get; set; }

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
        [Display(Name = "Publisher")]
        public string Publisher { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Title")]
        public string Title { get; set; }
    }
}
