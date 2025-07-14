using Mission.Entity;
using Microsoft.EntityFrameworkCore;
using Mission.Entity.Entities;
using Mission.Entity.Models.CommonModels;
using Mission.Entity.Models.StoryModels;
using Mission.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Mission.Repository.Repositories
{
    public class StoryRepository(MissionDbContext ciDbContext) : IStoryRepository
    {
        private readonly MissionDbContext _ciDbContext = ciDbContext;

        #region ClientSide

        public List<DropDownResponseModel> GetMissionTitle()
        {
            var missionTitleList = _ciDbContext.Missions
                .Where(m => !m.IsDeleted)
                .Select(m => new DropDownResponseModel(m.Id, m.MissionTitle))
                .ToList();

            return missionTitleList;
        }

        public string AddStory(AddStoryRequestModel model)
        {
            var newStory = new Story()
            {
                MissionId = model.MissionId,
                UserId = model.UserId,
                StoryTitle = model.StoryTitle,
                StoryDate = model.StoryDate,
                StoryDescription = model.StoryDescription,
                VideoUrl = model.VideoUrl,
                StoryImage = model.StoryImage,
                IsActive = false,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = null,
                IsDeleted = false
            };

            _ciDbContext.Story.Add(newStory);
            _ciDbContext.SaveChanges();

            return "Story Share Successfully..";
        }

        public List<StoryDetailResponseModel> ClientSideStoryList()
        {
            var storyList = _ciDbContext.Story
                .Where(s => s.IsActive
                    && !s.IsDeleted
                    && !s.Mission.IsDeleted
                    && !s.User.IsDeleted
                    && s.User.UserDetail != null
                    && !s.User.UserDetail.IsDeleted)
                .OrderBy(s => s.CreatedDate)
                .Select(s => new StoryDetailResponseModel()
                {
                    Id = s.Id,
                    MissionId = s.MissionId,
                    UserId = s.UserId,
                    UserFullName = $"{s.User.FirstName} {s.User.LastName}",
                    MissionTitle = s.Mission.MissionTitle,
                    StoryTitle = s.StoryTitle,
                    StoryDescription = s.StoryDescription,
                    VideoUrl = s.VideoUrl,
                    StoryImage = s.StoryImage,
                    IsActive = s.IsActive,
                    UserImage = s.User.UserDetail != null ? s.User.UserDetail.UserImage : string.Empty,
                    StoryViewerCount = s.StoryViewerCount
                })
                .ToList();

            return storyList;
        }

        public StoryDetailResponseModel StoryDetailById(int id)
        {
            _ciDbContext.Story
                .Where(s => s.Id == id)
                .ExecuteUpdate(s => s.SetProperty(property => property.StoryViewerCount, oldStory => (oldStory.StoryViewerCount ?? 0) + 1));

            var storyById = _ciDbContext.Story
                .Where(s => s.Id == id
                    && s.IsActive
                    && !s.IsDeleted
                    && !s.Mission.IsDeleted
                    && !s.User.IsDeleted
                    && s.User.UserDetail != null
                    && !s.User.UserDetail.IsDeleted)
                .Select(s => new StoryDetailResponseModel()
                {
                    Id = s.Id,
                    MissionId = s.MissionId,
                    UserId = s.UserId,
                    UserFullName = $"{s.User.FirstName} {s.User.LastName}",
                    MissionTitle = s.Mission.MissionTitle,
                    StoryTitle = s.StoryTitle,
                    StoryDescription = s.StoryDescription,
                    VideoUrl = s.VideoUrl,
                    StoryImage = s.StoryImage,
                    IsActive = s.IsActive,
                    UserImage = s.User.UserDetail != null ? s.User.UserDetail.UserImage : string.Empty,
                    StoryViewerCount = s.StoryViewerCount
                })
                .FirstOrDefault() ?? throw new Exception("Story not found.");

            return storyById;
        }
        #endregion

        #region AdminSide

        public List<StoryResponseModel> AdminSideStoryList()
        {
            var storyList = _ciDbContext.Story
               .Where(s => !s.IsDeleted
                   && !s.Mission.IsDeleted
                   && !s.User.IsDeleted)
               .OrderBy(s => s.CreatedDate)
               .Select(s => new StoryResponseModel()
               {
                   Id = s.Id,
                   MissionId = s.MissionId,
                   UserId = s.UserId,
                   UserFullName = $"{s.User.FirstName} {s.User.LastName}",
                   MissionTitle = s.Mission.MissionTitle,
                   StoryTitle = s.StoryTitle,
                   StoryDescription = s.StoryDescription,
                   VideoUrl = s.VideoUrl,
                   StoryImage = s.StoryImage,
                   IsActive = s.IsActive
               })
               .ToList();

            return storyList;
        }

        public string StoryStatusActive(StoryStatusActiveRequestModel model)
        {
            _ciDbContext.Story
                .Where(s => s.Id == model.Id)
                .ExecuteUpdate(s => s.SetProperty(property => property.IsActive, model.IsActive));

            return model.IsActive ? "Story Active Successfully.." : "Story DeActive Successfully..";
        }

        public string DeleteStory(int id)
        {
            _ciDbContext.Story
                .Where(s => s.Id == id)
                .ExecuteUpdate(s => s.SetProperty(property => property.IsDeleted, true));

            return "Delete Story Successfully..";
        }

        public StoryDetailAdminResponseModel StoryDetailByIdAdmin(int id)
        {
            var storyById = _ciDbContext.Story
               .Where(s => s.Id == id
                   && !s.IsDeleted
                   && !s.Mission.IsDeleted
                   && !s.User.IsDeleted
                   && s.User.UserDetail != null
                   && !s.User.UserDetail.IsDeleted)
               .Select(s => new StoryDetailAdminResponseModel()
               {
                   Id = s.Id,
                   MissionId = s.MissionId,
                   UserId = s.UserId,
                   UserFullName = $"{s.User.FirstName} {s.User.LastName}",
                   MissionTitle = s.Mission.MissionTitle,
                   StoryTitle = s.StoryTitle,
                   StoryDescription = s.StoryDescription,
                   VideoUrl = s.VideoUrl,
                   StoryImage = s.StoryImage,
                   IsActive = s.IsActive,
                   UserImage = s.User.UserDetail != null ? s.User.UserDetail.UserImage : string.Empty,
                   StoryDate = s.StoryDate
               })
               .FirstOrDefault() ?? throw new Exception("Story not found.");

            return storyById;
        }

        #endregion
    }
}
