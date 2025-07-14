using Mission.Entity.Models.MissionThemeModels;
using System.Collections.Generic;

namespace Mission.Service.IServices
{
    public interface IMissionThemeService
    {
        List<MissionThemeResponseModel> GetMissionThemeList();

        MissionThemeResponseModel GetMissionThemeById(int id);

        string AddMissionTheme(AddMissionThemeRequestModel model);

        string UpdateMissionTheme(UpdateMissionThemeRequestModel model);

        string DeleteMissionTheme(int id);
    }
}
