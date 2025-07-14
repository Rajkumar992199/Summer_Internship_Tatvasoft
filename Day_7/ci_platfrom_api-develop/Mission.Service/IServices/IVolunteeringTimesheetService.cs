using Mission.Entity.Models.CommonModels;
using Mission.Entity.Models.VolunteeringTimesheetModels;
using System.Collections.Generic;

namespace Mission.Service.IServices
{
    public interface IVolunteeringTimesheetService
    {
        #region Volunteering Hours

        List<VolunteeringHoursResponseModel> GetVolunteeringHoursList(int userId);

        VolunteeringHoursResponseModel GetVolunteeringHoursListById(int id);

        string AddVolunteeringHours(AddVolunteeringHoursRequestModel model);

        string UpdateVolunteeringHours(UpdateVolunteeringHoursRequestModel model);

        List<DropDownResponseModel> VolunteeringMissionList(int userId);

        string DeleteVolunteeringHours(int id);

        #endregion

        #region Volunteering Goals

        List<VolunteeringGoalsResponseModel> GetVolunteeringGoalsList(int userId);

        VolunteeringGoalsResponseModel GetVolunteeringGoalsListById(int id);

        string AddVolunteeringGoals(AddVolunteeringGoalsRequestModel model);

        string UpdateVolunteeringGoals(UpdateVolunteeringGoalsRequestModel model);

        string DeleteVolunteeringGoals(int id);

        #endregion
    }
}
