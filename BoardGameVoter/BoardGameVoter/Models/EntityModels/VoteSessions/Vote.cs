using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.VoteSessions
{
    [Table("Votes")]
    public class Vote : EntityBase
    {
        [NotMapped]
        public LibraryGame LibraryGame { get; set; }

        public int LibraryGameID { get; set; }
        public int NumberOfVotes { get; set; }
        public VoteSession VoteSession { get; set; }
        public int VoteSessionAttendeeID { get; set; }

        [ForeignKey("VoteSession")]
        public int VoteSessionID { get; set; }
    }
}
