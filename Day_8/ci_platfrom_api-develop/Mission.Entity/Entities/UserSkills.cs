using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission.Entity.Entities
{
    [Table("UserSkills")] // Specify the table name
    public class UserSkills : BaseEntity // Assuming BaseEntity defines common properties
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("skill")]
        public string Skill { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
    }
}
