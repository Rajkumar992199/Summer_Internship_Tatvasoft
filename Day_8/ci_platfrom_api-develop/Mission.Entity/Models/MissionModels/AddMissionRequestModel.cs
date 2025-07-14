using System;

namespace Mission.Entity.Models.MissionModels
{
    public class AddMissionRequestModel
    {
        public string MissionTitle { get; set; } = string.Empty;

        public string MissionDescription { get; set; } = string.Empty;

        public string MissionOrganisationName { get; set; } = string.Empty;

        public string MissionOrganisationDetail { get; set; } = string.Empty;

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string MissionType { get; set; } = string.Empty;

        public int? TotalSheets { get; set; }

        public DateTime? RegistrationDeadLine { get; set; }

        public int MissionThemeId { get; set; }

        public string MissionSkillId { get; set; } = string.Empty;

        public string MissionImages { get; set; } = string.Empty;

        public string MissionDocuments { get; set; } = string.Empty;

        public string MissionAvailability { get; set; } = string.Empty;

        public string MissionVideoUrl { get; set; } = string.Empty;
    }
}
