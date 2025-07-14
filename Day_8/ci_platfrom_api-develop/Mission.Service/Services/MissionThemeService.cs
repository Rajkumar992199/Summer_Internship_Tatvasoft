using Mission.Entity.Models.MissionThemeModels;
using Mission.Repository.IRepositories;
using Mission.Service.IServices;
using System.Collections.Generic;

namespace Mission.Service.Services
{
    public class MissionThemeService(IMissionThemeRepository missionThemeRepository) : IMissionThemeService
    {
        private readonly IMissionThemeRepository _missionThemeRepository = missionThemeRepository;

        public List<MissionThemeResponseModel> GetMissionThemeList()
        {
            return _missionThemeRepository.GetMissionThemeList();
        }

        public MissionThemeResponseModel GetMissionThemeById(int id)
        {
            return _missionThemeRepository.GetMissionThemeById(id);
        }

        public string AddMissionTheme(AddMissionThemeRequestModel model)
        {
            return _missionThemeRepository.AddMissionTheme(model);
        }

        public string UpdateMissionTheme(UpdateMissionThemeRequestModel model)
        {
            return _missionThemeRepository.UpdateMissionTheme(model);
        }

        public string DeleteMissionTheme(int id)
        {
            return _missionThemeRepository.DeleteMissionTheme(id);
        }
    }
}
