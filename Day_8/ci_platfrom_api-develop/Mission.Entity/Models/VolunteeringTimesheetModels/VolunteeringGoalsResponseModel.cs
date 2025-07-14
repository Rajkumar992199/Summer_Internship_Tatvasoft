using System;

namespace Mission.Entity.Models.VolunteeringTimesheetModels
{
    public class VolunteeringGoalsResponseModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int MissionId { get; set; }

        public string MissionName { get; set; }

        public DateTime Date { get; set; }

        public int Action { get; set; }

        public string Message { get; set; }
    }
}
