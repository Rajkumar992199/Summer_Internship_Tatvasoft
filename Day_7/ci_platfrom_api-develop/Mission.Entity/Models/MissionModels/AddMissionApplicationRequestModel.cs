using System;

namespace Mission.Entity.Models.MissionModels
{
    public class AddMissionApplicationRequestModel
    {
        public int MissionId { get; set; }

        public int UserId { get; set; }

        public DateTime AppliedDate { get; set; }

        public bool Status { get; set; }

        public int Sheet { get; set; }
    }
}
