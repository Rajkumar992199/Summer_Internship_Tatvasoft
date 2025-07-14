using Mission.Entity.Models.CommonModels;
using Mission.Entity.Models.StoryModels;
using System.Collections.Generic;

namespace Mission.Service.IServices
{
    public interface IStoryService
    {
        #region ClientSide

        List<DropDownResponseModel> GetMissionTitle();

        string AddStory(AddStoryRequestModel model);

        List<StoryDetailResponseModel> ClientSideStoryList();

        StoryDetailResponseModel StoryDetailById(int id);

        #endregion

        #region AdminSide

        List<StoryResponseModel> AdminSideStoryList();


        string StoryStatusActive(StoryStatusActiveRequestModel model);

        string DeleteStory(int id);

        StoryDetailAdminResponseModel StoryDetailByIdAdmin(int id);

        #endregion
    }
}
