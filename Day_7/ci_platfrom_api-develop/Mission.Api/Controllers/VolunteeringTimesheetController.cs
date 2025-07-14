using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mission.Entity.Entities;
using Mission.Entity.Models.VolunteeringTimesheetModels;
using Mission.Service.IServices;
using System;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteeringTimesheetController(IVolunteeringTimesheetService volunteeringTimesheetService) : ControllerBase
    {
        ResponseResult result = new ResponseResult();
        private readonly IVolunteeringTimesheetService _volunteeringTimesheetService = volunteeringTimesheetService;

        #region Volunteering Hours

        [HttpGet]
        [Route("GetVolunteeringHoursList/{userId}")]
        [Authorize]
        public ResponseResult GetVolunteeringHoursList(int userId)
        {
            try
            {
                result.Data = _volunteeringTimesheetService.GetVolunteeringHoursList(userId);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("GetVolunteeringHoursListById/{id}")]
        [Authorize]
        public ResponseResult GetVolunteeringHoursListById(int id)
        {
            try
            {
                result.Data = _volunteeringTimesheetService.GetVolunteeringHoursListById(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpGet]
        [Route("VolunteeringMissionList/{id}")]
        [Authorize]
        public ResponseResult VolunteeringMissionList(int id)
        {
            try
            {
                result.Data = _volunteeringTimesheetService.VolunteeringMissionList(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("AddVolunteeringHours")]
        [Authorize]
        public ResponseResult AddVolunteeringHours(AddVolunteeringHoursRequestModel model)
        {
            try
            {
                result.Data = _volunteeringTimesheetService.AddVolunteeringHours(model);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("UpdateVolunteeringHours")]
        [Authorize]
        public ResponseResult UpdateVolunteeringHours(UpdateVolunteeringHoursRequestModel model)
        {
            try
            {
                result.Data = _volunteeringTimesheetService.UpdateVolunteeringHours(model);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpDelete]
        [Route("DeleteVolunteeringHours/{id}")]
        [Authorize]
        public ResponseResult DeleteVolunteeringHours(int id)
        {
            try
            {
                result.Data = _volunteeringTimesheetService.DeleteVolunteeringHours(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        #endregion

        #region Volunteering Goals

        [HttpGet]
        [Route("GetVolunteeringGoalsList/{userId}")]
        [Authorize]
        public ResponseResult GetVolunteeringGoalsList(int userId)
        {
            try
            {
                result.Data = _volunteeringTimesheetService.GetVolunteeringGoalsList(userId);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("GetVolunteeringGoalsListById/{id}")]
        [Authorize]
        public ResponseResult GetVolunteeringGoalsListById(int id)
        {
            try
            {
                result.Data = _volunteeringTimesheetService.GetVolunteeringGoalsListById(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("AddVolunteeringGoals")]
        [Authorize]
        public ResponseResult AddVolunteeringGoals(AddVolunteeringGoalsRequestModel model)
        {
            try
            {
                result.Data = _volunteeringTimesheetService.AddVolunteeringGoals(model);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("UpdateVolunteeringGoals")]
        [Authorize]
        public ResponseResult UpdateVolunteeringGoals(UpdateVolunteeringGoalsRequestModel model)
        {
            try
            {
                result.Data = _volunteeringTimesheetService.UpdateVolunteeringGoals(model);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpDelete]
        [Route("DeleteVolunteeringGoals/{id}")]
        [Authorize]
        public ResponseResult DeleteVolunteeringGoals(int id)
        {
            try
            {
                result.Data = _volunteeringTimesheetService.DeleteVolunteeringGoals(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        #endregion
    }
}
