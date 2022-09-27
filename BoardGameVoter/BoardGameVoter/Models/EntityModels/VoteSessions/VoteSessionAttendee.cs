using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.VoteSessions
{
    [Table("VoteSessionAttendees")]
    public class VoteSessionAttendee : EntityBase
    {
        [NotMapped]
        public List<LibraryGame> LibraryGames { get; set; }

        [NotMapped]
        public User User { get; set; }

        public int UserID { get; set; }

        public VoteSession VoteSession { get; set; }

        [ForeignKey("VoteSession")]
        public int VoteSessionID { get; set; }

        public int VotesRemaining { get; set; }
    }
}
