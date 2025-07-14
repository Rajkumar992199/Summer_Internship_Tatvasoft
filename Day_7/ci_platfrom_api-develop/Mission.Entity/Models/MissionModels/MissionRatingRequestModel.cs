namespace Mission.Entity.Models.MissionModels
{
    public class MissionRatingRequestModel
    {
        public int MissionId { get; set; }

        public int UserId { get; set; }

        public int? Rating { get; set; }
    }
}
