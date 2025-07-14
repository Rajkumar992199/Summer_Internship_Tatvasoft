using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mission.Entity.Entities;
using Mission.Entity.Models.MissionThemeModels;
using Mission.Service.IServices;
using System;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionThemeController(IMissionThemeService missionThemeService) : ControllerBase
    {
        private readonly IMissionThemeService _missionThemeService = missionThemeService;
        ResponseResult result = new ResponseResult();

        [HttpGet]
        [Route("GetMissionThemeList")]
        [Authorize]
        public ResponseResult GetMissionThemeList()
        {
            try
            {
                result.Data = _missionThemeService.GetMissionThemeList();
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
        [Route("GetMissionThemeById/{id}")]
        [Authorize]
        public ResponseResult GetMissionThemeById(int id)
        {
            try
            {
                result.Data = _missionThemeService.GetMissionThemeById(id);
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
        [Route("AddMissionTheme")]
        [Authorize]
        public ResponseResult AddMissionTheme(AddMissionThemeRequestModel model)
        {
            try
            {
                result.Data = _missionThemeService.AddMissionTheme(model);
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
        [Route("UpdateMissionTheme")]
        [Authorize]
        public ResponseResult UpdateMissionTheme(UpdateMissionThemeRequestModel model)
        {
            try
            {
                result.Data = _missionThemeService.UpdateMissionTheme(model);
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
        [Route("DeleteMissionTheme/{id}")]
        [Authorize]
        public ResponseResult DeleteMissionTheme(int id)
        {
            try
            {
                result.Data = _missionThemeService.DeleteMissionTheme(id);
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
