using Mission.Entity.Models.CommonModels;
using Mission.Entity.Models.StoryModels;
using Mission.Repository.IRepositories;
using Mission.Service.IServices;
using System.Collections.Generic;

namespace Mission.Service.Services
{
    public class StoryService(IStoryRepository storyRepository) : IStoryService
    {
        private readonly IStoryRepository _storyRepository = storyRepository;

        #region ClientSide

        public List<DropDownResponseModel> GetMissionTitle()
        {
            return _storyRepository.GetMissionTitle();
        }

        public string AddStory(AddStoryRequestModel model)
        {
            return _storyRepository.AddStory(model);
        }

        public List<StoryDetailResponseModel> ClientSideStoryList()
        {
            return _storyRepository.ClientSideStoryList();
        }

        public StoryDetailResponseModel StoryDetailById(int id)
        {
            return _storyRepository.StoryDetailById(id);
        }

        #endregion

        #region AdminSide

        public List<StoryResponseModel> AdminSideStoryList()
        {
            return _storyRepository.AdminSideStoryList();
        }

        public string StoryStatusActive(StoryStatusActiveRequestModel model)
        {
            return _storyRepository.StoryStatusActive(model);
        }

        public string DeleteStory(int id)
        {
            return _storyRepository.DeleteStory(id);
        }

        public StoryDetailAdminResponseModel StoryDetailByIdAdmin(int id)
        {
            return _storyRepository.StoryDetailByIdAdmin(id);
        }

        #endregion
    }
}
