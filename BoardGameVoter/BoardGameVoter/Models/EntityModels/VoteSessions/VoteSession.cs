using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.VoteSessions
{
    [Table("VoteSessions")]
    public class VoteSession : EntityBase
    {
        public DateTime GameDate { get; set; }

        [NotMapped]
        public User Host { get; set; }

        public int HostUserID { get; set; }
        public bool IsPublic { get; set; }
        public bool IsVotingOpen { get; set; }

        [NotMapped]
        public LibraryGame LeadGame { get; set; }

        public int? LeadGameID { get; set; }

        [NotMapped]
        public Location Location { get; set; }

        public int LocationID { get; set; }

        [NotMapped]
        public virtual List<Vote> Votes { get; set; }

        public int VotesCast { get; set; }

        [NotMapped]
        public virtual List<VoteSessionAttendee> VoteSessionAttendees { get; set; }

        [NotMapped]
        public virtual List<VoteSessionResult> VoteSessionResults { get; set; }
    }
}
