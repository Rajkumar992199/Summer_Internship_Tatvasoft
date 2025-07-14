using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission.Entity.Entities
{

    [Table("VolunteeringGoals")] // Specify the table name
    public class VolunteeringGoals : BaseEntity // Assuming BaseEntity defines common properties
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("mission_id")]
        public int MissionId { get; set; }

        [Column("date", TypeName = "Date")]
        public DateTime Date { get; set; }

        [Column("action")]
        public int Action { get; set; }

        [Column("message")]
        public string Message { get; set; }

        [ForeignKey(nameof(MissionId))]
        public virtual Missions Mission { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
