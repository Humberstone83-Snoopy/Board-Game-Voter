using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Models.Enums;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.BoardGames;
using BoardGameVoter.Repositorys.Library;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BoardGameVoter.Pages.Library
{
    public class UpdateModel : BoardGameVoterPageBase
    {
        private const string DELETE_ACTION = "DELETE";
        private const string REDIRECT_ACTION = "REDIRECT";
        private const string SAVE_ACTION = "SAVE";

        private readonly BoardGameCategoryRepository __BoardGameCategoryRepository;
        private readonly BoardGameMechanismRepository __BoardGameMechanismRepository;
        private readonly BoardGameRepository __BoardGameRepository;
        private readonly BoardGameTypeRepository __BoardGameTypeRepository;
        private readonly LibraryGameRepository __LibraryGameRepository;

        public UpdateModel(IBGVServiceProvider bGVServiceProvider)
            : base(bGVServiceProvider)
        {
            __BoardGameCategoryRepository = new BoardGameCategoryRepository(bGVServiceProvider);
            __BoardGameMechanismRepository = new BoardGameMechanismRepository(bGVServiceProvider);
            __BoardGameTypeRepository = new BoardGameTypeRepository(bGVServiceProvider);
            __BoardGameRepository = new BoardGameRepository(bGVServiceProvider);
            __LibraryGameRepository = new LibraryGameRepository(bGVServiceProvider);
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

        private void PopulateCategories()
        {
            IEnumerable<BoardGameCategory> _Categories = __BoardGameCategoryRepository.GetAll();
            BoardGameCategories = new List<SelectListItem>();
            foreach (BoardGameCategory category in _Categories)
            {
                BoardGameCategories.Add(new(category.Name, category.ID.ToString()));
            }
        }

        private void PopulateForm()
        {
            PopulateSelects();

            Nickname = LibraryGame.Name;
            Title = BoardGame.Title;
            TagLine = BoardGame.Description_Short;
            Description = BoardGame.Description_Long;
            AgeRating = BoardGame.AgeRating;
            GameWeight = BoardGame.Weight ?? Weight.Undefined;
            MaximumPlayers = BoardGame.MaximumPlayers ?? MinimumPlayers;
            MinimumPlayers = BoardGame.MinimumPlayers;
            MaximumPlayTime = BoardGame.MaximumPlayTime ?? 0;
            MinimumPlayTime = BoardGame.MinimumPlayTime ?? 0;
            Publisher = BoardGame.Publisher ?? string.Empty;
            IsActive = LibraryGame.IsAvailable;
            ReleaseDate = BoardGame.ReleaseDate.GetValueOrDefault(DateTime.MinValue);

            PrimaryCategory = BoardGame.PrimaryCategoryID > 0 ? __BoardGameCategoryRepository.GetByID(BoardGame.PrimaryCategoryID ?? 0)?.Name ?? null : null;
            PrimaryType = BoardGame.PrimaryTypeID > 0 ? __BoardGameTypeRepository.GetByID(BoardGame.PrimaryTypeID ?? 0)?.Name ?? null : null;
            PrimaryMechanism = BoardGame.PrimaryMechanismID > 0 ? __BoardGameMechanismRepository.GetByID(BoardGame.PrimaryMechanismID ?? 0)?.Name ?? null : null;
            SecondaryCategory = BoardGame.SecondaryCategoryID > 0 ? __BoardGameCategoryRepository.GetByID(BoardGame.SecondaryCategoryID ?? 0)?.Name ?? null : null;
            SecondaryType = BoardGame.SecondaryTypeID > 0 ? __BoardGameTypeRepository.GetByID(BoardGame.SecondaryTypeID ?? 0)?.Name ?? null : null;
            SecondaryMechanism = BoardGame.SecondaryMechanismID > 0 ? __BoardGameMechanismRepository.GetByID(BoardGame.SecondaryMechanismID ?? 0)?.Name ?? null : null;
            TertiaryCategory = BoardGame.TertiaryCategoryID > 0 ? __BoardGameCategoryRepository.GetByID(BoardGame.TertiaryCategoryID ?? 0)?.Name ?? null : null;
            TertiaryMechanism = BoardGame.TertiaryMechanismID > 0 ? __BoardGameMechanismRepository.GetByID(BoardGame.TertiaryMechanismID ?? 0)?.Name ?? null : null;
        }

        private void PopulateMechanisms()
        {
            IEnumerable<BoardGameMechanism> _Mechanisms = __BoardGameMechanismRepository.GetAll();
            BoardGameMechanisms = new List<SelectListItem>();
            foreach (BoardGameMechanism mechanism in _Mechanisms)
            {
                BoardGameMechanisms.Add(new(mechanism.Name, mechanism.ID.ToString()));
            }
        }

        private void PopulateSelects()
        {
            PopulateCategories();
            PopulateTypes();
            PopulateMechanisms();
        }

        private void PopulateTypes()
        {
            IEnumerable<BoardGameType> _Types = __BoardGameTypeRepository.GetAll();
            BoardGameTypes = new List<SelectListItem>();
            foreach (BoardGameType type in _Types)
            {
                BoardGameTypes.Add(new(type.Name, type.ID.ToString()));
            }
        }

        private void Update()
        {
            if (ModelState.IsValid)
            {
                UpdateBoardGame();

                LibraryGame.Name = Nickname;
                LibraryGame.IsAvailable = IsActive;
                __LibraryGameRepository.Update(LibraryGame);
            }
        }

        private void UpdateBoardGame()
        {
            //TODO: Add amend access levels so that only those with admin clearance can fully update board game entries.

            //int.TryParse(PrimaryCategory, out int _PrimaryCategoryID);
            //int.TryParse(PrimaryType, out int _PrimaryTypeID);
            //int.TryParse(PrimaryMechanism, out int _PrimaryMechanismID);
            //int.TryParse(SecondaryCategory, out int _SecondaryCategoryID);
            //int.TryParse(SecondaryType, out int _SecondaryTypeID);
            //int.TryParse(SecondaryMechanism, out int _SecondaryMechanismID);
            //int.TryParse(TertiaryCategory, out int _TertiaryCategoryID);
            //int.TryParse(TertiaryMechanism, out int _TertiaryMechanismID);

            if (BoardGame.Weight == Weight.Undefined)
            {
                BoardGame.Weight = GameWeight;

                //BoardGame.PrimaryCategoryID = _PrimaryCategoryID > 0 ? _PrimaryCategoryID : null;
                //BoardGame.PrimaryTypeID = _PrimaryTypeID > 0 ? _PrimaryTypeID : null;
                //BoardGame.PrimaryMechanismID = _PrimaryMechanismID > 0 ? _PrimaryMechanismID : null;
                //BoardGame.SecondaryCategoryID = _SecondaryCategoryID > 0 ? _SecondaryCategoryID : null;
                //BoardGame.SecondaryTypeID = _SecondaryTypeID > 0 ? _SecondaryTypeID : null;
                //BoardGame.SecondaryMechanismID = _SecondaryMechanismID > 0 ? _SecondaryMechanismID : null;
                //BoardGame.TertiaryCategoryID = _TertiaryCategoryID > 0 ? _TertiaryCategoryID : null;
                //BoardGame.TertiaryMechanismID = _TertiaryMechanismID > 0 ? _TertiaryMechanismID : null;

                __BoardGameRepository.Update(BoardGame);
            }
        }

        [BindProperty]
        public string Action { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Age Rating")]
        public string AgeRating { get; set; }

        private BoardGame BoardGame { get; set; }
        public List<SelectListItem> BoardGameCategories { get; set; }
        public List<SelectListItem> BoardGameMechanisms { get; set; }
        public List<SelectListItem> BoardGameTypes { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [BindProperty]
        public bool DisableInputs { get; set; } = true;

        [BindProperty]
        [Required]
        [Display(Name = "Weight")]
        public Weight GameWeight { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

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
        [Display(Name = "Nickname")]
        public string Nickname { get; set; }

        [BindProperty]
        [Display(Name = "Categories:")]
        public string? PrimaryCategory { get; set; }

        [BindProperty]
        [Display(Name = "Mechanics:")]
        public string? PrimaryMechanism { get; set; }

        [BindProperty]
        [Display(Name = "Types:")]
        public string? PrimaryType { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Publisher")]
        public string Publisher { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "ReleaseDate")]
        public DateTime ReleaseDate { get; set; }

        [BindProperty]
        public string? SecondaryCategory { get; set; }

        [BindProperty]
        public string? SecondaryMechanism { get; set; }

        [BindProperty]
        public string? SecondaryType { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Tag Line")]
        public string TagLine { get; set; }

        [BindProperty]
        public string? TertiaryCategory { get; set; }

        [BindProperty]
        public string? TertiaryMechanism { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
    }
}
