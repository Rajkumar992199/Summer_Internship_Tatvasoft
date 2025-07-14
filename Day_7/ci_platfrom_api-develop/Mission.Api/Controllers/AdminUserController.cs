using Microsoft.AspNetCore.Mvc;
using Mission.Entity.Entities;
using Mission.Service.IServices;
using System;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController(IAdminUserService _adminUserService) : ControllerBase
    {
        ResponseResult result = new ResponseResult();
        private readonly IAdminUserService _adminUserService = _adminUserService;

        [HttpGet]
        [Route("UserDetailList")]
        public ResponseResult UserDetailList()
        {
            try
            {
                result.Data = _adminUserService.UserDetailList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Success;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpDelete]
        [Route("DeleteUser/{userId}")]
        public ResponseResult DeleteUser(int userId)
        {
            try
            {
                result.Data = _adminUserService.DeleteUser(userId);
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
