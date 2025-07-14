using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace Mission.Entity.Models.LoginModels
{
    public class RegisterUserRequestModel
    {
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("email_address")]
        public string EmailAddress { get; set; }

        [Column("user_type")]
        public string UserType { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("user_image")]
        [JsonIgnore]
        public IFormFile ProfileImage { get; set; } // optional
    }
}
