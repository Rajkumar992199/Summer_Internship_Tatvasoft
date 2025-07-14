using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mission.Entity.Entities;
using Mission.Entity.Models.CMSModels;
using Mission.Service.IServices;
using System;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CMSController(ICMSService cmsService) : ControllerBase
    {
        ResponseResult result = new ResponseResult();
        private readonly ICMSService _cmsService = cmsService;

        [HttpGet]
        [Route("CMSList")]
        [Authorize]
        public ResponseResult CMSList()
        {
            try
            {
                result.Data = _cmsService.CMSList();
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
        [Route("CMSDetailById/{id}")]
        [Authorize]
        public ResponseResult CMSDetailById(int id)
        {
            try
            {
                result.Data = _cmsService.CMSDetailById(id);
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
        [Route("AddCMS")]
        [Authorize]
        public ResponseResult AddCMS(AddCMSRequestModel model)
        {
            try
            {
                result.Data = _cmsService.AddCMS(model);
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
        [Route("UpdateCMS")]
        [Authorize]
        public ResponseResult UpdateCMS(UpdateCMSRequestModel model)
        {
            try
            {
                result.Data = _cmsService.UpdateCMS(model);
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
        [Route("DeleteCMS/{id}")]
        [Authorize]
        public ResponseResult DeleteCMS(int id)
        {
            try
            {
                result.Data = _cmsService.DeleteCMS(id);
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
