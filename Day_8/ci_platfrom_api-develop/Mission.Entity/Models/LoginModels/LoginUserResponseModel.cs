namespace Mission.Entity.Models.LoginModels
{
    public class LoginUserResponseModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string UserType { get; set; }

        public string UserImage { get; set; }

        public string Message { get; set; }
    }
}
