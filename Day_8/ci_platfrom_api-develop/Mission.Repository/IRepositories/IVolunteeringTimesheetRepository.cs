using Mission.Entity.Models.CommonModels;
using Mission.Entity.Models.VolunteeringTimesheetModels;
using System.Collections.Generic;

namespace Mission.Repository.IRepositories
{
    public interface IVolunteeringTimesheetRepository
    {
        #region Volunteeting Hours

        List<VolunteeringHoursResponseModel> GetVolunteeringHoursList(int userId);

        VolunteeringHoursResponseModel GetVolunteeringHoursListById(int id);

        string AddVolunteeringHours(AddVolunteeringHoursRequestModel model);

        List<DropDownResponseModel> VolunteeringMissionList(int userId);

        string UpdateVolunteeringHours(UpdateVolunteeringHoursRequestModel model);

        string DeleteVolunteeringHours(int id);

        #endregion

        #region Volunteeting Goals

        List<VolunteeringGoalsResponseModel> GetVolunteeringGoalsList(int userId);

        VolunteeringGoalsResponseModel GetVolunteeringGoalsListById(int id);

        string AddVolunteeringGoals(AddVolunteeringGoalsRequestModel model);

        string UpdateVolunteeringGoals(UpdateVolunteeringGoalsRequestModel model);

        string DeleteVolunteeringGoals(int id);

        #endregion
    }
}
