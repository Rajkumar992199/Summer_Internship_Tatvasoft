using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission.Entity.Entities
{
    [Table("CMS")]
    public class CMS
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("slug")]
        public string Slug { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("created_date")]
        public DateTimeOffset? CreatedDate { get; set; } // Use DateTimeOffset instead of DateTime

        [Column("modified_date")]
        public DateTimeOffset? ModifiedDate { get; set; } // Use DateTimeOffset instead of DateTime

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
    }
}
