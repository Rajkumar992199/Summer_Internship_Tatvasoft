using System;

namespace Mission.Entity.Models.VolunteeringTimesheetModels
{
    public class AddVolunteeringHoursRequestModel
    {
        public int UserId { get; set; }

        public int MissionId { get; set; }

        public DateTime DateVolunteered { get; set; }

        public string Hours { get; set; }

        public string Minutes { get; set; }

        public string Message { get; set; }
    }
}
