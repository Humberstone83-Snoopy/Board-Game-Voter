using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.BoardGames
{
    [Table("BoardGameCategories")]
    public class BoardGameCategory : EntityBase
    {
        public string Name { get; set; }
    }
}
