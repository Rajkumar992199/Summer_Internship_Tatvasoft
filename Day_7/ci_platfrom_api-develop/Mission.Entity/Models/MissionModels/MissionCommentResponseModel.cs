using System;

namespace Mission.Entity.Models.MissionModels
{
    public class MissionCommentResponseModel
    {
        public int Id { get; set; }

        public int MissionId { get; set; }

        public int UserId { get; set; }

        public string CommentDescription { get; set; }

        public DateTime? CommentDate { get; set; }

        public string UserFullName { get; set; }

        public string UserImage { get; set; }
    }
}
