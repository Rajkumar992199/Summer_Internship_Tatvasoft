using Microsoft.EntityFrameworkCore;
using Mission.Entity.Entities;
using Mission.Entity.Models.AdminUserModels;
using Mission.Repository.IRepositories;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Mission.Repository.Repositories
{
    public class AdminUserRepository(MissionDbContext cIDbContext) : IAdminUserRepository
    {
        private readonly MissionDbContext _cIDbContext = cIDbContext;

        public List<UserDetailResponseModel> UserDetailList()
        {
            var userDetails = _cIDbContext.User
                .Where(u => !u.IsDeleted && u.UserType == "user")
                .Select(u => new UserDetailResponseModel(u))
                .ToList();

            return userDetails;
        }

        public string DeleteUser(int userId)
        {
            _cIDbContext.User.Where(ud => ud.Id == userId).ExecuteUpdate(ud => ud.SetProperty(property => property.IsDeleted, true));

            return "Delete User Successfully..";
        }
    }
}
