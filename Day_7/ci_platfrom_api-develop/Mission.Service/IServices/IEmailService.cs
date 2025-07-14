using Mission.Entity.Models.EmailModels;

namespace Mission.Service.IServices
{
    public interface IEmailService
    {
        void SendEmail(EmailRequestModel request);
    }
}
