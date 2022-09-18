using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels
{
    [Table("Votes")]
    public class Vote : EntityBase
    {
        public int LibraryGameID { get; set; }
        public int NumberOfVotes { get; set; }
        public int VoteSessionAttendeeID { get; set; }
        public int VoteSessionID { get; set; }
    }
}
