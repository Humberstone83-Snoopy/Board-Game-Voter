using BoardGamer.BoardGameGeek.BoardGameGeekXmlApi2;
using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Models.POCO;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameVoter.Services.GeekService
{
    [Route("api/[controller]")]
    public class GeekController : Controller
    {
        private readonly IBGVServiceProvider __BGVServiceProvider;
        private readonly IBoardGameGeekXmlApi2Client __BoardGameGeekAPI2Client;

        public GeekController(IBGVServiceProvider bgvServiceProvider, IBoardGameGeekXmlApi2Client bggClient)
        {
            __BGVServiceProvider = bgvServiceProvider;
            __BoardGameGeekAPI2Client = bggClient;
        }

        public async Task<List<ThingResponse.Item>> SearchAsync(string searchRequestString)
        {
            List<ThingResponse.Item> _Games = new();
            SearchResponse _SearchResponse = await __BoardGameGeekAPI2Client.SearchAsync(new SearchRequest(searchRequestString, "boardgame"));
            IEnumerable<SearchResponse.Item> _SearchResults = _SearchResponse.Result.Items;
            if (_SearchResults != null && _SearchResults.Any())
            {
                ThingResponse _ThingResponse = await __BoardGameGeekAPI2Client.GetThingAsync(new ThingRequest(_SearchResults.Select(games => games.Id).ToArray()));

                if (_ThingResponse.Succeeded)
                {
                    _Games.AddRange(_ThingResponse.Result);
                }
            }
            return _Games;
        }

        public async Task<BoardGameGeekSearchResult> GetBoardGameAsync(int boardGameGeekID)
        {
            BoardGameGeekSearchResult _Result = null;
            if(boardGameGeekID > 0)
            {
                ThingResponse _ThingResponse = await __BoardGameGeekAPI2Client.GetThingAsync(new ThingRequest(new List<int>() { boardGameGeekID }, null, false, false, true));
                if(_ThingResponse.Succeeded)
                {
                    BoardGame _BoardGame = GeekAdapter.ToBoardGame(__BGVServiceProvider, _ThingResponse.Result.FirstOrDefault());
                    _Result = new()
                    {
                        BoardGame = _BoardGame,
                        ThingItem = _ThingResponse.Result.FirstOrDefault()
                    };
                }
            }
            return _Result;
        }
    }
}