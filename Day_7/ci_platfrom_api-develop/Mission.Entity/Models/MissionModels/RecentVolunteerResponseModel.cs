namespace Mission.Entity.Models.MissionModels
{
    public class RecentVolunteerResponseModel
    {
        public int Id { get; set; }

        public int MissionId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserImage { get; set; }
    }
}
