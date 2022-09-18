using System.ComponentModel.DataAnnotations;

namespace BoardGameVoter.Models.Shared
{
    public class EntityBase : IEntityBase
    {
        [Key]
        public int ID { get; set; }
        public Guid UID { get; set; }
    }
}
