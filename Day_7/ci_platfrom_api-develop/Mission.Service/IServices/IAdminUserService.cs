using Mission.Entity.Models.AdminUserModels;
using System.Collections.Generic;

namespace Mission.Service.IServices
{
    public interface IAdminUserService
    {
        List<UserDetailResponseModel> UserDetailList();

        string DeleteUser(int userId);
    }
}
