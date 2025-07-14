using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission.Entity.Entities
{
    [Table("Missions")] // Specify the table name
    public class Missions : BaseEntity // Assuming BaseEntity defines common properties
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("mission_title")]
        public string MissionTitle { get; set; }

        [Column("mission_description")]
        public string MissionDescription { get; set; }

        [Column("mission_organisation_name")]
        public string MissionOrganisationName { get; set; }

        [Column("mission_organisation_detail")]
        public string MissionOrganisationDetail { get; set; }

        [Column("country_id")]
        public int CountryId { get; set; }

        [Column("city_id")]
        public int CityId { get; set; }

        [Column("start_date", TypeName = "Date")]
        public DateTime StartDate { get; set; }

        [Column("end_date", TypeName = "Date")]
        public DateTime EndDate { get; set; }

        [Column("mission_type")]
        public string MissionType { get; set; }

        [Column("total_sheets")]
        public int? TotalSheets { get; set; }

        [Column("registration_deadline", TypeName = "Date")]
        public DateTime? RegistrationDeadLine { get; set; }

        [Column("mission_theme_id")]
        public int MissionThemeId { get; set; }

        [Column("mission_skill_id")]
        public string MissionSkillId { get; set; }

        [Column("mission_images")]
        public string MissionImages { get; set; }

        [Column("mission_documents")]
        public string MissionDocuments { get; set; }

        [Column("mission_availability")]
        public string MissionAvailability { get; set; }

        [Column("mission_video_url")]
        public string MissionVideoUrl { get; set; }

        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; } = null!;

        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; } = null!;

        [ForeignKey(nameof(MissionThemeId))]
        public virtual MissionTheme MissionTheme { get; set; } = null!;

        public virtual ICollection<MissionApplication> MissionApplications { get; set; } = [];

        public virtual ICollection<MissionFavourites> MissionFavourites { get; set; } = [];

        public virtual ICollection<MissionRating> MissionRatings { get; set; } = [];

        public virtual ICollection<MissionComment> MissionComments { get; set; } = [];

        public virtual ICollection<Story> Stories { get; set; } = [];

        public virtual ICollection<VolunteeringHours> VolunteeringHours { get; set; } = [];

        public virtual ICollection<VolunteeringGoals> VolunteeringGoals { get; set; } = [];
    }
}
