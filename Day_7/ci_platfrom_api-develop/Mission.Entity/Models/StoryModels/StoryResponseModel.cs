namespace Mission.Entity.Models.StoryModels
{
    public class StoryResponseModel
    {
        public int Id { get; set; }

        public int MissionId { get; set; }

        public int UserId { get; set; }

        public string UserFullName { get; set; }

        public string MissionTitle { get; set; }

        public string StoryTitle { get; set; }

        public string StoryDescription { get; set; }

        public string VideoUrl { get; set; }

        public string StoryImage { get; set; }

        public bool IsActive { get; set; }
    }
}
