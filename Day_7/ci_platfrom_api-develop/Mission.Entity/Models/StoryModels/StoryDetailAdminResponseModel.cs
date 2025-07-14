using System;

namespace Mission.Entity.Models.StoryModels
{
    public class StoryDetailAdminResponseModel : StoryResponseModel
    {
        public string UserImage { get; set; }

        public DateTime StoryDate { get; set; }
    }
}
