using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.BoardGames;
using BoardGameVoter.Repositorys.Library;
using BoardGameVoter.Services;

namespace BoardGameVoter.Pages.Library.Add
{
    public class SearchModel : BoardGameVoterPageBase
    {
        private readonly BoardGameRepository __BoardGameRepository;
        private readonly LibraryGameRepository __LibraryGameRepository;

        public SearchModel(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
            __BoardGameRepository = new BoardGameRepository(bGVServiceProvider);
            __LibraryGameRepository = new LibraryGameRepository(bGVServiceProvider);
        }

        public void OnGet()
        {
            List<int> _MyGameIDs = __LibraryGameRepository.GetByUserID(UserManager.User.ID).Select(game => game.BoardGameID).ToList();
            BoardGames = __BoardGameRepository.GetAll().Where(game => !_MyGameIDs.Contains(game.ID)).ToList();
        }

        public List<BoardGame> BoardGames { get; private set; }
    }
}
