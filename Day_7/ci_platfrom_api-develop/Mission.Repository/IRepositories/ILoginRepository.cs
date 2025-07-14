using Mission.Entity.Models.LoginModels;
using System.Threading.Tasks;

namespace Mission.Repository.IRepositories
{
    public interface ILoginRepository
    {
        Task<string> Register(RegisterUserRequestModel model, string webRootPath);

        LoginUserResponseModel LoginUser(LoginUserRequestModel model);

        Task<string> ForgotPassword(ForgotPasswordRequestModel model, int userId);

        Task<string> ResetPassword(ResetPasswordRequestModel model);

        string ChangePassword(ChangePasswordRequestModel model);

        UserResponseModel LoginUserDetailById(int id);

        Task<string> UpdateUser(UserRequestModel model, string webRootPath);

        UserDetailResponseModel GetUserProfileDetailById(int userId);

        string LoginUserProfileUpdate(AddUpdateUserDetailRequestModel model);

        Task<UserRequestModel> GetUserByEmail(string email);

    }
}
