using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mission.Entity.Entities;
using Mission.Entity.Models.MissionModels;
using Mission.Service.IServices;
using System;
using System.Collections.Generic;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientMissionController(IMissionService missionService) : ControllerBase
    {
        ResponseResult result = new ResponseResult();
        private readonly IMissionService _missionService = missionService;

        [HttpGet]
        [Route("ClientSideMissionList/{userId}")]
        public ResponseResult ClientSideMissionList(int userId)
        {
            try
            {
                result.Data = _missionService.ClientSideMissionList(userId);
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
        [Route("MissionClientList")]
        public ResponseResult MissionClientList(MissionDetailRequestModel data)
        {
            try
            {
                result.Data = _missionService.MissionClientList(data);
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
        [Route("ApplyMission")]
        public ResponseResult ApplyMission(AddMissionApplicationRequestModel model)
        {
            try
            {
                result.Data = _missionService.ApplyMission(model);
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
        [Route("MissionDetailByMissionId")]
        [Authorize]
        public ResponseResult MissionDetailByMissionId(MissionDetailRequestModel data)
        {
            try
            {
                result.Data = _missionService.MissionDetailByMissionId(data);
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
        [Route("AddMissionComment")]
        public ResponseResult AddMissionComment(AddMissionCommentRequestModel missionComment)
        {
            try
            {
                result.Data = _missionService.AddMissionComment(missionComment);
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
        [Route("MissionCommentListByMissionId/{missionId}")]
        public ResponseResult MissionCommentListByMissionId(int missionId)
        {
            try
            {
                result.Data = _missionService.MissionCommentListByMissionId(missionId);
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
        [Route("AddMissionFavourite")]
        public ResponseResult AddMissionFavourite(AddRemoveMissionFavouriteRequestModel model)
        {
            try
            {
                result.Data = _missionService.AddMissionFavourite(model);
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
        [Route("RemoveMissionFavourite")]
        public ResponseResult RemoveMissionFavourite(AddRemoveMissionFavouriteRequestModel missionFavourites)
        {
            try
            {
                result.Data = _missionService.RemoveMissionFavourite(missionFavourites);
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
        [Route("MissionRating")]
        public ResponseResult MissionRating(MissionRatingRequestModel model)
        {
            try
            {
                result.Data = _missionService.MissionRating(model);
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
        [Route("RecentVolunteerList")]
        public ResponseResult RecentVolunteerList(MissionApplication missionApplication)
        {
            try
            {
                result.Data = _missionService.RecentVolunteerList(missionApplication);
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
        [Route("GetUserList/{userId}")]
        public ResponseResult GetUserList(int userId)
        {
            try
            {
                result.Data = _missionService.GetUserList(userId);
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
        [Route("SendInviteMissionMail")]
        public ResponseResult SendInviteMissionMail(List<MissionShareInviteRequestModel> user)
        {
            try
            {
                result.Data = _missionService.SendInviteMissionMail(user);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
