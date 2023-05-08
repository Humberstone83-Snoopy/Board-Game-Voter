using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.Shared
{
    public class EntityBase : IEntityBase
    {
        [Key]
        public int ID { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UID { get; set; }
    }
}
