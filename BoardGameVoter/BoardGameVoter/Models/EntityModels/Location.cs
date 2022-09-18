using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels
{
    [Table("Locations")]
    public class Location : EntityBase
    {
        public string Address { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }
        public string Name { get; set; }
        public string Postcode { get; set; }
    }
}
