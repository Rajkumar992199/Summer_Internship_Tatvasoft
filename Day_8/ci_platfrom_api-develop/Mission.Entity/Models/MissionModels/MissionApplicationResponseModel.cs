using System;

namespace Mission.Entity.Models.MissionModels
{
    public class MissionApplicationResponseModel
    {
        public int Id { get; set; }

        public int MissionId { get; set; }

        public string MissionTitle { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserImage { get; set; }

        public DateTime AppliedDate { get; set; }

        public bool Status { get; set; }

        public int Sheet { get; set; }
        public string MissionTheme { get; set; }
    }
}
