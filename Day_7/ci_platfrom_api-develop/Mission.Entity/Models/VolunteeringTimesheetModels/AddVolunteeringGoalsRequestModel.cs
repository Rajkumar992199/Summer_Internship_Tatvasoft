using System;

namespace Mission.Entity.Models.VolunteeringTimesheetModels
{
    public class AddVolunteeringGoalsRequestModel
    {
        public int UserId { get; set; }

        public int MissionId { get; set; }

        public DateTime Date { get; set; }

        public int Action { get; set; }

        public string Message { get; set; }
    }
}
