using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.BoardGames;
using BoardGameVoter.Repositorys.Library;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameVoter.Pages.Library.Add
{
    public class ExistingModel : BoardGameVoterPageBase
    {
        private readonly BoardGameRepository __BoardGameRepository;
        private readonly LibraryGameRepository __LibraryGameRepository;

        public ExistingModel(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
            __BoardGameRepository = new BoardGameRepository(bGVServiceProvider);
            __LibraryGameRepository = new LibraryGameRepository(bGVServiceProvider);
        }

        public void OnGet()
        {
            if (BoardGame_UID == Guid.Empty)
            {
                throw new ArgumentException(nameof(BoardGame_UID), "Valid UID must be passed");
            }
            BoardGame? _Game = __BoardGameRepository.GetByUID(BoardGame_UID);
            if (_Game == null)
            {
                throw new ArgumentNullException(nameof(BoardGame), "Game does not Exist");
            }
            __LibraryGameRepository.Add(new LibraryGame()
            {
                BoardGameID = _Game.ID,
                IsAvailable = true,
                Name = _Game.Title,
                UserID = UserManager.User.ID,
                Votes = 0
            });
            
            Response.Redirect("/library");
        }

        [BindProperty(SupportsGet = true)]
        public Guid BoardGame_UID { get; set; }
    }
}
