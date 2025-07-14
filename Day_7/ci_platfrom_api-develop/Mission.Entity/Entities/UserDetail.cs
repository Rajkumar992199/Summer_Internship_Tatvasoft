using Mission.Entity.Models.LoginModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission.Entity.Entities
{
    [Table("UserDetail")] // Specify the table name
    public class UserDetail : BaseEntity // Assuming BaseEntity defines common properties
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("surname")]
        public string Surname { get; set; }

        [Column("employee_id")]
        public string EmployeeId { get; set; }

        [Column("manager")]
        public string Manager { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("department")]
        public string Department { get; set; }

        [Column("my_profile")]
        public string MyProfile { get; set; }

        [Column("why_i_volunteer")]
        public string WhyIVolunteer { get; set; }

        [Column("country_id")]
        public int CountryId { get; set; }

        [Column("city_id")]
        public int CityId { get; set; }

        [Column("availability")]
        public string Availability { get; set; }

        [Column("linkd_in_url")]
        public string LinkedInUrl { get; set; }

        [Column("my_skills")]
        public string MySkills { get; set; }

        [Column("user_image")]
        public string UserImage { get; set; }

        [Column("status")]
        public bool Status { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } = null!;
    }
}
