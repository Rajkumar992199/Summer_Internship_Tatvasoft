namespace Mission.Entity.Models.StoryModels
{
    public class StoryDetailResponseModel : StoryResponseModel
    {
        public string UserImage { get; set; }

        public int? StoryViewerCount { get; set; } = 0;
    }
}
