using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission.Entity.Entities
{
    [Table("MissionTheme")] // Specify the table name
    public class MissionTheme : BaseEntity // Assuming BaseEntity defines common properties
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("theme_name")]
        public string ThemeName { get; set; }

        [Column("status")]
        public string Status { get; set; }

        public virtual ICollection<Missions> Missions { get; set; } = [];
    }
}
