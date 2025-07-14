using Mission.Entity.Models.AdminUserModels;
using System.Collections.Generic;

namespace Mission.Repository.IRepositories
{
    public interface IAdminUserRepository
    {
        List<UserDetailResponseModel> UserDetailList();

        string DeleteUser(int userId);
    }
}
