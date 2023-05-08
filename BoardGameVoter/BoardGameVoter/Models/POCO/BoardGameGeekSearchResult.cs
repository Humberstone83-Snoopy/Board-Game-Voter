using BoardGameVoter.Models.EntityModels.BoardGames;
using static BoardGamer.BoardGameGeek.BoardGameGeekXmlApi2.ThingResponse;

namespace BoardGameVoter.Models.POCO
{
    public class BoardGameGeekSearchResult
    {
        public Item ThingItem { get; set; }
        public BoardGame BoardGame { get; set; }
    }
}
