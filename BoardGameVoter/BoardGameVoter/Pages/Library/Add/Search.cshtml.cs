using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.BoardGames;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoardGameVoter.Pages.Library.Add
{
    public class SearchModel : BoardGameVoterPageBase
    {
        private readonly BoardGameRepository __BoardGameRepository;

        public SearchModel(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
            __BoardGameRepository = new BoardGameRepository(bGVServiceProvider);
        }

        public void OnGet()
        {
            BoardGames = __BoardGameRepository.GetAll().ToList();
        }

        public List<BoardGame> BoardGames { get; private set; }
    }
}
