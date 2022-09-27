using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.VoteSessions
{
    [Table("VoteSessionResults")]
    public class VoteSessionResult : EntityBase
    {
        [NotMapped]
        public LibraryGame LibraryGame { get; set; }

        public int LibraryGameID { get; set; }
        public VoteSession VoteSession { get; set; }

        [ForeignKey("VoteSession")]
        public int VoteSessionID { get; set; }
    }
}
