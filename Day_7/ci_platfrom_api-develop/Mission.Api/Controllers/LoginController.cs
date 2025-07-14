using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Mission.Entity.Entities;
using Mission.Entity.Models.LoginModels;
using Mission.Service.IServices;
using System;
using System.Threading.Tasks;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(ILoginService loginService, IWebHostEnvironment hostingEnvironment) : ControllerBase
    {
        private readonly ILoginService _loginService = loginService;
        private readonly IWebHostEnvironment _hostingEnvironment = hostingEnvironment;
        ResponseResult result = new ResponseResult();

        [HttpPost]
        [Route("LoginUser")]
        public ResponseResult LoginUser(LoginUserRequestModel model)
       {
            try
            {
                result.Data = _loginService.LoginUser(model);
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
        [Route("Register")]
        public async Task<ResponseResult> RegisterUser([FromForm] RegisterUserRequestModel model)
        {
            try
            {
                result.Data = await _loginService.Register(model, _hostingEnvironment.WebRootPath);
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
        [Route("ForgotPassword")]
        public async Task<bool> ForgotPassword(ForgotPasswordRequestModel model)
        {
            return await _loginService.ForgotPassword(model);
        }

        [HttpPost]
        [Route("ResetPassword")]
        public async Task<string> ResetPassword(ResetPasswordRequestModel model)
        {
            return await _loginService.ResetPassword(model);
        }

        [HttpGet]
        [Route("LoginUserDetailById/{id}")]
        public ResponseResult LoginUserDetailById(int id)
        {
            try
            {
                result.Data = _loginService.LoginUserDetailById(id);
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
        [Route("UpdateUser")]
        public async Task<ResponseResult> UpdateUser(UserRequestModel model)
        {
            try
            {
                result.Data = await _loginService.UpdateUser(model, _hostingEnvironment.WebRootPath);
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
        [Route("GetUserProfileDetailById/{userId}")]
        public ResponseResult GetUserProfileDetailById(int userId)
        {
            try
            {
                result.Data = _loginService.GetUserProfileDetailById(userId);
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
        [Route("LoginUserProfileUpdate")]
        [Authorize]
        public ResponseResult LoginUserProfileUpdate(AddUpdateUserDetailRequestModel model)
        {
            try
            {
                result.Data = _loginService.LoginUserProfileUpdate(model);
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
        [Route("ChangePassword")]
        [Authorize]
        public ResponseResult ChangePassword(ChangePasswordRequestModel model)
        {
            try
            {
                result.Data = _loginService.ChangePassword(model);
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
