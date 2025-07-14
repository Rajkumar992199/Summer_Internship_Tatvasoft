using Mission.Entity.Entities;
using Mission.Entity.Models.LoginModels;
using System.Threading.Tasks;

namespace Mission.Service.IServices
{
    public interface ILoginService
    {
        Task<string> Register(RegisterUserRequestModel model, string webRootPath);

        ResponseResult LoginUser(LoginUserRequestModel model);

        LoginUserResponseModel UserLogin(LoginUserRequestModel model);

        Task<bool> ForgotPassword(ForgotPasswordRequestModel model);

        Task<string> ResetPassword(ResetPasswordRequestModel model);

        UserResponseModel LoginUserDetailById(int id);

        Task<string> UpdateUser(UserRequestModel model, string webRootPath);

        UserDetailResponseModel GetUserProfileDetailById(int userId);

        string LoginUserProfileUpdate(AddUpdateUserDetailRequestModel model);

        string ChangePassword(ChangePasswordRequestModel changePassword);
    }
}
