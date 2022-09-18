using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels
{
    [Table("VoteSessionResults")]
    public class VoteSessionResult : EntityBase
    {
        public int VoteSessionID { get; set; }
        public int LibraryGameID { get; set; }
    }
}
