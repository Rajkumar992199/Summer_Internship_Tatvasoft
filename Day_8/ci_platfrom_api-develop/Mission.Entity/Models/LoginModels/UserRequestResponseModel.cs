using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
namespace Mission.Entity.Models.LoginModels
{
    public class UserRequestModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string UserType { get; set; }

        [JsonIgnore]
        public IFormFile ProfileImage { get; set; }
    }

    public class UserResponseModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string UserType { get; set; }

        public string ProfileImage { get; set; } // For returning stored image URL/path
    }
}
