using Mission.Entity.Models.MissionSkillModels;
using Mission.Repository.IRepositories;
using Mission.Service.IServices;
using System.Collections.Generic;

namespace Mission.Service.Services
{
    public class MissionSkillService(IMissionSkillRepository missionSkillRepository) : IMissionSkillService
    {
        private readonly IMissionSkillRepository _missionSkillRepository = missionSkillRepository;

        public List<MissionSkillResponseModel> GetMissionSkillList()
        {
            return _missionSkillRepository.GetMissionSkillList();
        }

        public MissionSkillResponseModel GetMissionSkillById(int id)
        {
            return _missionSkillRepository.GetMissionSkillById(id);
        }

        public string AddMissionSkill(AddMissionSkillRequestModel model)
        {
            return _missionSkillRepository.AddMissionSkill(model);
        }

        public string UpdateMissionSkill(UpdateMissionSkillRequestModel model)
        {
            return _missionSkillRepository.UpdateMissionSkill(model);
        }

        public string DeleteMissionSkill(int id)
        {
            return _missionSkillRepository.DeleteMissionSkill(id);
        }
    }
}
