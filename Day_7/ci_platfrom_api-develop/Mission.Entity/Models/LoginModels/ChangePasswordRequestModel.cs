namespace Mission.Entity.Models.LoginModels
{
    public class ChangePasswordRequestModel
    {
        public int UserId { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
