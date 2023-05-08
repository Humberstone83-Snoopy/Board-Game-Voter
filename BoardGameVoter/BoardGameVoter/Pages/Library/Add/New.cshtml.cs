using BoardGamer.BoardGameGeek.BoardGameGeekXmlApi2;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Models.Enums;
using BoardGameVoter.Models.POCO;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.BoardGames;
using BoardGameVoter.Repositorys.Library;
using BoardGameVoter.Services;
using BoardGameVoter.Services.GeekService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoardGameVoter.Pages.Library.Add
{
    public class NewModel : BoardGameVoterPageBase
    {
        private readonly GeekController __GeekController;
        private readonly BoardGameRepository __BoardGameRepository;
        private readonly BoardGameImageRepository __BoardGameImageRepository;
        private readonly LibraryGameRepository __LibraryGameRepository;

        public NewModel(IBGVServiceProvider bGVServiceProvider, GeekController geekController) : base(bGVServiceProvider)
        {
            __GeekController = geekController;
            __BoardGameRepository = new BoardGameRepository(bGVServiceProvider);
            __BoardGameImageRepository = new BoardGameImageRepository(bGVServiceProvider);
            __LibraryGameRepository = new LibraryGameRepository(bGVServiceProvider);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                BGGSearchResults = await __GeekController.SearchAsync(Search);
            }
            return Page();
        }

        //TODO: Add Handler Call
        public async Task OnPostAddAsync(int id)
        {
            if(id > 0)
            {
                BoardGame _ExistingBoardGame = __BoardGameRepository.GetByBoardGameGeekID(id);
                if(_ExistingBoardGame != null)
                {
                    __LibraryGameRepository.AddNew(UserManager.User, _ExistingBoardGame);
                }
                else
                {
                    BoardGameGeekSearchResult _NewBoardGame = await __GeekController.GetBoardGameAsync(id);
                    BoardGame _SavedGame = __BoardGameRepository.Add(_NewBoardGame.BoardGame);
                    //TODO: Save Board Game and all sub entities
                    //TODO: Add Library Game
                }
                Response.Redirect("/library");
            }
        }

        public IActionResult OnGet()
        {
            List<int> _MyGameIDs = __LibraryGameRepository.GetByUserID(UserManager.User.ID).Select(game => game.BoardGameID).ToList();
            DBBoardGames = __BoardGameRepository.GetAll().Where(game => !_MyGameIDs.Contains(game.ID)).ToList();
            
            return Page();
        }

        public List<BoardGame> DBBoardGames { get; private set; }

        [DisplayName("Search")]
        [BindProperty]
        public string Search { get; set; }

        public List<ThingResponse.Item> BGGSearchResults { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
    }
}
