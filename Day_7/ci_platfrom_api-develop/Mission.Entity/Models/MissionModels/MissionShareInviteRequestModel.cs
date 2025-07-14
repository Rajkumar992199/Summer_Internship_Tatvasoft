namespace Mission.Entity.Models.MissionModels
{
    public class MissionShareInviteRequestModel
    {
        public string UserFullName { get; set; }

        public string EmailAddress { get; set; }

        public string MissionShareUserEmailAddress { get; set; }

        public string BaseUrl { get; set; }

        public int MissionId { get; set; }
    }
}
