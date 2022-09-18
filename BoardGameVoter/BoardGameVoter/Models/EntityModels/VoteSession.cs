using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels
{
    [Table("VoteSessions")]
    public class VoteSession : EntityBase
    {
        public int ChosenGameID { get; set; }
        public DateTime GameDate { get; set; }
        public int HostUserID { get; set; }
        public bool IsPublic { get; set; }
        public bool IsVotingOpen { get; set; }
        public int LocationID { get; set; }
        public int VotesCast { get; set; }
    }
}
