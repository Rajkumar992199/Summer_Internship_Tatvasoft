using Mission.Entity.Models.MissionThemeModels;
using System.Collections.Generic;

namespace Mission.Repository.IRepositories
{
    public interface IMissionThemeRepository
    {
        List<MissionThemeResponseModel> GetMissionThemeList();

        MissionThemeResponseModel GetMissionThemeById(int id);

        string AddMissionTheme(AddMissionThemeRequestModel model);

        string UpdateMissionTheme(UpdateMissionThemeRequestModel model);

        string DeleteMissionTheme(int id);
    }
}
