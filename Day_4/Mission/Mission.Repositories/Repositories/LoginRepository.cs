using Mission.Entities.Context;
using Mission.Entities.Entities;
using Mission.Repositories.IRepositories;

namespace Mission.Repositories.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly MissionDbContext _dbContext;
        public LoginRepository(MissionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User? GetUserByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(users => users.EmailAddress == email);
        }

    }
}
