using Mission.Entity.Entities;

namespace Mission.Entity.Models.AdminUserModels
{
    public class UserDetailResponseModel
    {
        public UserDetailResponseModel() { }

        public UserDetailResponseModel(User user) 
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            PhoneNumber = user.PhoneNumber;
            EmailAddress = user.EmailAddress;
            UserType = user.UserType;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string UserType { get; set; }
    }
}
