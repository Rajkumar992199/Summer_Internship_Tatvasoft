using Mission.Entity.Models.CommonModels;
using Mission.Entity.Models.VolunteeringTimesheetModels;
using Mission.Repository.IRepositories;
using Mission.Service.IServices;
using System.Collections.Generic;

namespace Mission.Service.Services
{
    public class VolunteeringTimesheetService(IVolunteeringTimesheetRepository volunteeringTimesheetRepository) : IVolunteeringTimesheetService
    {
        private readonly IVolunteeringTimesheetRepository _volunteeringTimesheetRepository = volunteeringTimesheetRepository;

        #region Volunteering Hours

        public List<VolunteeringHoursResponseModel> GetVolunteeringHoursList(int userId)
        {
            return _volunteeringTimesheetRepository.GetVolunteeringHoursList(userId);
        }

        public VolunteeringHoursResponseModel GetVolunteeringHoursListById(int id)
        {
            return _volunteeringTimesheetRepository.GetVolunteeringHoursListById(id);
        }

        public string AddVolunteeringHours(AddVolunteeringHoursRequestModel model)
        {
            return _volunteeringTimesheetRepository.AddVolunteeringHours(model);
        }

        public string UpdateVolunteeringHours(UpdateVolunteeringHoursRequestModel model)
        {
            return _volunteeringTimesheetRepository.UpdateVolunteeringHours(model);
        }

        public List<DropDownResponseModel> VolunteeringMissionList(int userId)
        {
            return _volunteeringTimesheetRepository.VolunteeringMissionList(userId);
        }

        public string DeleteVolunteeringHours(int id)
        {
            return _volunteeringTimesheetRepository.DeleteVolunteeringHours(id);
        }

        #endregion

        #region Volunteering Goals

        public List<VolunteeringGoalsResponseModel> GetVolunteeringGoalsList(int userId)
        {
            return _volunteeringTimesheetRepository.GetVolunteeringGoalsList(userId);
        }

        public VolunteeringGoalsResponseModel GetVolunteeringGoalsListById(int id)
        {
            return _volunteeringTimesheetRepository.GetVolunteeringGoalsListById(id);
        }

        public string AddVolunteeringGoals(AddVolunteeringGoalsRequestModel model)
        {
            return _volunteeringTimesheetRepository.AddVolunteeringGoals(model);
        }

        public string UpdateVolunteeringGoals(UpdateVolunteeringGoalsRequestModel model)
        {
            return _volunteeringTimesheetRepository.UpdateVolunteeringGoals(model);
        }

        public string DeleteVolunteeringGoals(int id)
        {
            return _volunteeringTimesheetRepository.DeleteVolunteeringGoals(id);
        }

        #endregion
    }
}
