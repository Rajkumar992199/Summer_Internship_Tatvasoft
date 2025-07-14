using Mission.Entity.Models.AdminUserModels;
using Mission.Repository.IRepositories;
using Mission.Service.IServices;
using System.Collections.Generic;

namespace Mission.Service.Services
{
    public class AdminUserService(IAdminUserRepository adminUserRepository) : IAdminUserService
    {
        private readonly IAdminUserRepository _adminUserRepository = adminUserRepository;

        public List<UserDetailResponseModel> UserDetailList()
        {
            return _adminUserRepository.UserDetailList();
        }

        public string DeleteUser(int userId)
        {
            return _adminUserRepository.DeleteUser(userId);
        }
    }
}
