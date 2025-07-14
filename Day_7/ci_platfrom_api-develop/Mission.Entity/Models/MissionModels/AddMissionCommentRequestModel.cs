using System;

namespace Mission.Entity.Models.MissionModels
{
    public class AddMissionCommentRequestModel
    {
        public int MissionId { get; set; }

        public int UserId { get; set; }

        public string CommentDescription { get; set; }

        public DateTime? CommentDate { get; set; }
    }
}
