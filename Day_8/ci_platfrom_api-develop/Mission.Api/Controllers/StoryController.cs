using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mission.Entity.Entities;
using Mission.Entity.Models.StoryModels;
using Mission.Service.IServices;
using System;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController(IStoryService storyService) : ControllerBase
    {
        private readonly IStoryService _storyService = storyService;
        ResponseResult result = new ResponseResult();

        #region ClientSide


        [HttpGet]
        [Route("GetMissionTitle")]
        public ResponseResult GetMissionTitle()
        {
            try
            {
                result.Data = _storyService.GetMissionTitle();
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
        [Route("AddStory")]
        public ResponseResult AddStory(AddStoryRequestModel model)
        {
            try
            {
                result.Data = _storyService.AddStory(model);
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
        [Route("ClientSideStoryList")]
        public ResponseResult ClientSideStoryList()
        {
            try
            {
                result.Data = _storyService.ClientSideStoryList();
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
        [Route("StoryDetailById/{id}")]
        public ResponseResult StoryDetailById(int id)
        {
            try
            {
                result.Data = _storyService.StoryDetailById(id);
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

        #region AdminSide


        [HttpGet]
        [Route("AdminSideStoryList")]
        [Authorize]
        public ResponseResult AdminSideStoryList()
        {
            try
            {
                result.Data = _storyService.AdminSideStoryList();
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
        [Route("StoryStatusActive")]
        [Authorize]
        public ResponseResult StoryStatusActive(StoryStatusActiveRequestModel model)
        {
            try
            {
                result.Data = _storyService.StoryStatusActive(model);
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
        [Route("DeleteStory/{id}")]
        [Authorize]
        public ResponseResult DeleteStory(int id)
        {
            try
            {
                result.Data = _storyService.DeleteStory(id);
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
        [Route("StoryDetailByIdAdmin/{id}")]
        [Authorize]
        public ResponseResult StoryDetailByIdAdmin(int id)
        {
            try
            {
                result.Data = _storyService.StoryDetailByIdAdmin(id);
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
