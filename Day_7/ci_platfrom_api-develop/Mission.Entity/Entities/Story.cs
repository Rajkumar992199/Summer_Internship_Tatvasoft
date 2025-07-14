using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission.Entity.Entities
{
    [Table("Story")] // Specify the table name
    public class Story : BaseEntity // Assuming BaseEntity defines common properties
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("mission_id")]
        public int MissionId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("story_title")]
        public string StoryTitle { get; set; }

        [Column("story_date")]
        public DateTime StoryDate { get; set; }

        [Column("story_description")]
        public string StoryDescription { get; set; }

        [Column("video_url")]
        public string VideoUrl { get; set; }

        [Column("story_image")]
        public string StoryImage { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("story_viewer_count")]
        public int? StoryViewerCount { get; set; } = 0;

        [ForeignKey(nameof(MissionId))]
        public virtual Missions Mission { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } = null!;
    }
}
