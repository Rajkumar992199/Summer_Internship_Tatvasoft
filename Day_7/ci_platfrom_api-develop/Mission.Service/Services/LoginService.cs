using Microsoft.AspNetCore.Http;
using Mission.Entity.Entities;
using Mission.Entity.Models.LoginModels;
using Mission.Repository.IRepositories;
using Mission.Repository.JWTService;
using Mission.Service.IServices;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Mission.Service.Services
{
    public class LoginService(ILoginRepository loginRepository, JwtService jwtService) : ILoginService
    {
        private readonly ILoginRepository _loginRepository = loginRepository;
        private readonly JwtService _jwtService = jwtService;
        ResponseResult result = new ResponseResult();

        public async Task<string> Register(RegisterUserRequestModel model, string webRootPath)
        {
            return await _loginRepository.Register(model, webRootPath);
        }

        public ResponseResult LoginUser(LoginUserRequestModel model)
        {
            var userObj = UserLogin(model);

            if (userObj.Message.ToString() == "Login Successfully")
            {
                result.Message = userObj.Message;
                result.Result = ResponseStatus.Success;
                result.Data = _jwtService.GenerateToken(userObj.Id.ToString(), userObj.FirstName, userObj.LastName, userObj.PhoneNumber, userObj.EmailAddress, userObj.UserType, userObj.UserImage);
            }
            else
            {
                result.Message = userObj.Message;
                result.Result = ResponseStatus.Error;
            }
            return result;
        }

        public LoginUserResponseModel UserLogin(LoginUserRequestModel model)
        {
            return _loginRepository.LoginUser(model);
        }

        public async Task<bool> ForgotPassword(ForgotPasswordRequestModel model)
        {
            var user = await _loginRepository.GetUserByEmail(model.EmailAddress);

            if (user == null) return false;

            var id = await _loginRepository.ForgotPassword(model, user.Id);

            try
            {
                string callbackurl = model.BaseUrl + "/resetPassword?Uid=" + id;
                string mailTo = user.EmailAddress;
                string userName = user.FirstName + " " + user.LastName;
                string emailBody = "Hi " + userName + ",<br/><br/> Click the link below to reset your password <br/><br/> " + callbackurl;

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient();

                mail.From = new MailAddress("sourabh.patidar@tatvasoft.com");
                mail.To.Add(mailTo);
                mail.Subject = "Reset Password";
                mail.Body = emailBody;
                mail.IsBodyHtml = true;

                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential("sourabh.patidar@tatvasoft.com", "Bow88327");
                SmtpServer.EnableSsl = true;
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp-mail.outlook.com"; // Outlook SMTP server

                SmtpServer.Send(mail);

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<string> ResetPassword(ResetPasswordRequestModel model)
        {
            return await _loginRepository.ResetPassword(model);
        }

        public UserResponseModel LoginUserDetailById(int id)
        {
            return _loginRepository.LoginUserDetailById(id);
        }

        public async Task<string> UpdateUser(UserRequestModel model, string webRootPath)
        {
            return await loginRepository.UpdateUser(model, webRootPath);
        }

        public UserDetailResponseModel GetUserProfileDetailById(int userId)
        {
            return _loginRepository.GetUserProfileDetailById(userId);
        }

        public string LoginUserProfileUpdate(AddUpdateUserDetailRequestModel model)
        {
            return _loginRepository.LoginUserProfileUpdate(model);
        }

        public string ChangePassword(ChangePasswordRequestModel changePassword)
        {
            return _loginRepository.ChangePassword(changePassword);
        }
    }
}
