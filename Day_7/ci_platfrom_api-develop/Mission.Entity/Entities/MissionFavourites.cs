using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission.Entity.Entities
{
    [Table("MissionFavourites")] // Specify the table name
    public class MissionFavourites : BaseEntity // Assuming BaseEntity defines common properties
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("mission_id")]
        public int MissionId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey(nameof(MissionId))]
        public virtual Missions Mission { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } = null!;
    }
}
