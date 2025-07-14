using System;

namespace Mission.Entity.Models.StoryModels
{
    public class AddStoryRequestModel
    {
        public int MissionId { get; set; }

        public int UserId { get; set; }

        public string StoryTitle { get; set; }

        public DateTime StoryDate { get; set; }

        public string StoryDescription { get; set; }

        public string VideoUrl { get; set; }

        public string StoryImage { get; set; }
    }
}
