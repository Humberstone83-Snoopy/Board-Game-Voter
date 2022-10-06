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

namespace BoardGameVoter.Pages.Library.Add
{
    public class NewModel : BoardGameVoterPageBase
    {
        private readonly BoardGameCategoryRepository __BoardGameCategoryRepository;
        private readonly BoardGameMechanismRepository __BoardGameMechanismRepository;
        private readonly BoardGameTypeRepository __BoardGameTypeRepository;
        private readonly BoardGameRepository __BoardGameRepository;
        private readonly LibraryGameRepository __LibraryGameRepository;

        public NewModel(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
            __BoardGameCategoryRepository = new BoardGameCategoryRepository(bGVServiceProvider);
            __BoardGameMechanismRepository = new BoardGameMechanismRepository(bGVServiceProvider);
            __BoardGameTypeRepository = new BoardGameTypeRepository(bGVServiceProvider);
            __BoardGameRepository = new BoardGameRepository(bGVServiceProvider);
            __LibraryGameRepository = new LibraryGameRepository(bGVServiceProvider);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                int.TryParse(PrimaryCategory, out int _PrimaryCategoryID);
                int.TryParse(PrimaryType, out int _PrimaryTypeID);
                int.TryParse(PrimaryMechanism, out int _PrimaryMechanismID);
                int.TryParse(SecondaryCategory, out int _SecondaryCategoryID);
                int.TryParse(SecondaryType, out int _SecondaryTypeID);
                int.TryParse(SecondaryMechanism, out int _SecondaryMechanismID);
                int.TryParse(TertiaryCategory, out int _TertiaryCategoryID);
                int.TryParse(TertiaryMechanism, out int _TertiaryMechanismID);
                BoardGame? _Game = __BoardGameRepository.Add(new BoardGame()
                {
                    AgeRating = AgeRating,
                    Description_Long = Description,
                    Description_Short = TagLine,
                    MaximumPlayers = MaximumPlayers,
                    MaximumPlayTime = MaximumPlayTime,
                    MinimumPlayers = MinimumPlayers,
                    MinimumPlayTime = MinimumPlayTime,
                    PrimaryCategoryID = _PrimaryCategoryID > 0 ? _PrimaryCategoryID : null,
                    PrimaryTypeID = _PrimaryTypeID > 0 ? _PrimaryTypeID : null,
                    PrimaryMechanismID = _PrimaryMechanismID > 0 ? _PrimaryMechanismID : null,
                    SecondaryCategoryID = _SecondaryCategoryID > 0 ? _SecondaryCategoryID : null,
                    SecondaryTypeID = _SecondaryTypeID > 0 ? _SecondaryTypeID : null,
                    SecondaryMechanismID = _SecondaryMechanismID > 0 ? _SecondaryMechanismID : null,
                    TertiaryCategoryID = _TertiaryCategoryID > 0 ? _TertiaryCategoryID : null,
                    TertiaryMechanismID = _TertiaryMechanismID > 0 ? _TertiaryMechanismID : null,
                    Publisher = Publisher,
                    Rating = 0,
                    ReleaseDate = ReleaseDate,
                    Title = Title,
                    Weight = GameWeight
                });
                if(_Game != null)
                {
                    __LibraryGameRepository.Add(new LibraryGame()
                    {
                        BoardGameID = _Game.ID,
                        IsAvailable = true,
                        Name = _Game.Title,
                        UserID = UserManager.User.ID,
                        Votes = 0
                    });
                }
                Response.Redirect("/library");
            }
            return OnGet();
        }

        public IActionResult OnGet()
        {
            PopulateSelects();
            return Page();
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
            PopulateWeight();
        }

        private void PopulateWeight()
        {
            WeightEnums = Enum.GetValues<Weight>().Where(weight => weight != Weight.Undefined).Select(item => new SelectListItem { Text = item.ToString(), Value = item.ToString()}).ToList();
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

        [BindProperty]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Age Rating *")]
        public string AgeRating { get; set; }

        public List<SelectListItem> WeightEnums { get; set; }
        public List<SelectListItem> BoardGameCategories { get; set; }
        public List<SelectListItem> BoardGameMechanisms { get; set; }
        public List<SelectListItem> BoardGameTypes { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Description *")]
        public string Description { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Weight *")]
        public Weight GameWeight { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Maximum Players *")]
        public int MaximumPlayers { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Maximum Play Time *")]
        public int MaximumPlayTime { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Minimum Players *")]
        public int MinimumPlayers { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Minimum Play Time *")]
        public int MinimumPlayTime { get; set; }

        [BindProperty]
        [Display(Name = "Choose up to 3 Categories:")]
        public string? PrimaryCategory { get; set; }

        [BindProperty]
        [Display(Name = "Choose up to 3 Mechanics:")]
        public string? PrimaryMechanism { get; set; }

        [BindProperty]
        [Display(Name = "Choose up to 2 Types:")]
        public string? PrimaryType { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Publisher *")]
        public string Publisher { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "ReleaseDate *")]
        public DateTime ReleaseDate { get; set; } = DateTime.Today;

        [BindProperty]
        public string? SecondaryCategory { get; set; }

        [BindProperty]
        public string? SecondaryMechanism { get; set; }

        [BindProperty]
        public string? SecondaryType { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Tag Line *")]
        public string TagLine { get; set; }

        [BindProperty]
        public string? TertiaryCategory { get; set; }

        [BindProperty]
        public string? TertiaryMechanism { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Title *")]
        public string Title { get; set; }
    }
}
